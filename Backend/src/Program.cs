using System.ComponentModel;
using Asmpt.Application.Services;
using Asmpt.Domain.Interfaces;
using Asmpt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("SmtOrderManagementApp", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "https://ambitious-river-08f962c03.7.azurestaticapps.net")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

//execute database migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try{
        var context = services.GetRequiredService<DataContext>();
        context.Database.Migrate();
    }

    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


// Swagger UI
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
app.UseCors("SmtOrderManagementApp");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();