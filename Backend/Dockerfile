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
RUN dotnet test "tests/Tests.csproj" -c Release --no-build

# build the project
WORKDIR "/app/src"
RUN dotnet build "Project.csproj" -c Release -o /app/build

# small image to execute build stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Project.dll"]

