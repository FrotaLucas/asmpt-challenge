using Asmpt.Application.DTOs.Component;
using Asmpt.Application.Services;
using Asmpt.Domain.Entities;
using Asmpt.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;


public class ComponentServiceTests
{
    private readonly IMapper _mapper;

    public ComponentServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Component, ComponentResponseDto>();
            cfg.CreateMap<ComponentRequestDto, Component>();
        });

        _mapper = config.CreateMapper();
    }

    private DataContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new DataContext(options);
    }

    private ComponentService GetService(DataContext context)
    {
        return new ComponentService(
            context,
            new NullLogger<ComponentService>(),
            _mapper
        );
    }

    [Fact]
    public async Task CreateComponent_Should_Return_Success()
    {
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var dto = new ComponentRequestDto
        {
            Code = "C1",
            Name = "Component 1",
            Description = "Test component"
        };

        var result = await service.CreateComponentAsync(dto);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal("C1", result.Data.Code);
    }

    [Fact]
    public async Task GetAllComponents_Should_Return_Failure_When_Empty()
    {
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var result = await service.GetAllComponentsAsync();

        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Equal("No components found.", result.Message);
    }

    [Fact]
    public async Task GetComponentById_Should_Return_Failure_When_NotFound()
    {
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var result = await service.GetComponentByIdAsync(999);

        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Contains("not found", result.Message);
    }

    [Fact]
    public async Task DeleteComponent_Should_Remove_Component()
    {
        var context = GetInMemoryDbContext();

        context.Components.Add(new Component
        {
            Code = "C1",
            Name = "Component 1",
            Description = "Test"
        });

        await context.SaveChangesAsync();

        var service = GetService(context);

        var result = await service.DeleteComponentAsync(1);

        Assert.True(result.Success);
        Assert.True(result.Data);
    }

    [Fact]
    public async Task UpdateComponent_Should_Update_Values()
    {
        var context = GetInMemoryDbContext();

        context.Components.Add(new Component
        {
            Code = "Old",
            Name = "Old Name",
            Description = "Old Desc"
        });

        await context.SaveChangesAsync();

        var service = GetService(context);

        var updateDto = new ComponentRequestDto
        {
            Id = 1,
            Code = "New",
            Name = "New Name",
            Description = "New Desc"
        };

        var result = await service.UpdateComponentAsync(updateDto);

        Assert.True(result.Success);
        Assert.Equal("New", result.Data.Code);
        Assert.Equal("New Name", result.Data.Name);
    }
}
