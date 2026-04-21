FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["src/Project.csproj", "src"]
COPY ["tests/Tests.csproj", "tests"]
RUN dotnet restore "src/Project.csproj"
RUN dotnet restore "tests/Tests.csproj"

COPY . .
WORKDIR "/app/src"
RUN dotnet build "Project.csproj" -c Release -o /app/build

FROM build AS final
WORKDIR /app/build
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Project.dll"]

