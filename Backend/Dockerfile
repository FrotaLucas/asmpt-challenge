FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["src/Project.csproj", "src/"]
COPY ["tests/Tests.csproj", "tests/"]
RUN dotnet restore "src/Project.csproj"
RUN dotnet restore "tests/Tests.csproj"

# copy all missing code
COPY . .

# run tests
WORKDIR "/app/tests"
RUN dotnet test "tests/Tests.csproj" -c Release --no-restore

# publish the project
WORKDIR "/app/src"
RUN dotnet publish "Project.csproj" -c Release --no-restore -o /app/publish

# small image to execute publish stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Project.dll"]

