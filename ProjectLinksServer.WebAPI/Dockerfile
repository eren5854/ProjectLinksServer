FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# wwwroot klasörünü oluþtur ve yazma yetkisi ver
RUN mkdir -p /app/wwwroot && chmod -R 777 /app/wwwroot

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjectLinksServer.WebAPI/ProjectLinksServer.WebAPI.csproj", "ProjectLinksServer.WebAPI/"]
RUN dotnet restore "./ProjectLinksServer.WebAPI/ProjectLinksServer.WebAPI.csproj"
COPY . .
WORKDIR "/src/ProjectLinksServer.WebAPI"
RUN dotnet build "./ProjectLinksServer.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjectLinksServer.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# wwwroot klasörünü oluþtur ve yazma yetkisi ver
RUN mkdir -p /app/wwwroot && chmod -R 777 /app/wwwroot

ENTRYPOINT ["dotnet", "ProjectLinksServer.WebAPI.dll"]