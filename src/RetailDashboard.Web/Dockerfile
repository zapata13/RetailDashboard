# Stage 1: Build
FROM registry.access.redhat.com/ubi8/dotnet-80 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["src/RetailDashboard.Web/RetailDashboard.Web.csproj", "src/RetailDashboard.Web/"]
COPY ["src/RetailDashboard.Core/RetailDashboard.Core.csproj", "src/RetailDashboard.Core/"]
RUN dotnet restore "src/RetailDashboard.Web/RetailDashboard.Web.csproj"

# Copy everything else and build
COPY src/ src/
WORKDIR "/app/src/RetailDashboard.Web"
RUN dotnet publish "RetailDashboard.Web.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM registry.access.redhat.com/ubi8/dotnet-80-runtime AS final
WORKDIR /opt/app-root/app
COPY --from=build /app/publish .

# 12-factor: Export ports and entrypoint
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "RetailDashboard.Web.dll"]
