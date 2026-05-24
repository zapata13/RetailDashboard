# Stage 1: Build
FROM registry.access.redhat.com/ubi8/dotnet-80 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["src/RetailDashboard.Api/RetailDashboard.Api.csproj", "src/RetailDashboard.Api/"]
COPY ["src/RetailDashboard.Core/RetailDashboard.Core.csproj", "src/RetailDashboard.Core/"]
RUN dotnet restore "src/RetailDashboard.Api/RetailDashboard.Api.csproj"

# Copy everything else and build
COPY src/ src/
WORKDIR "/app/src/RetailDashboard.Api"
RUN dotnet publish "RetailDashboard.Api.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM registry.access.redhat.com/ubi8/dotnet-80-runtime AS final
WORKDIR /opt/app-root/app
COPY --from=build /app/publish .

# 12-factor: Export ports and entrypoint
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "RetailDashboard.Api.dll"]
