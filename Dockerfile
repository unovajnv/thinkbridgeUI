# Build and publish stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["ThinkBridge.csproj", "./"]
RUN dotnet restore "ThinkBridge.csproj"

# Copy all source code
COPY . .

# Build and publish the application
RUN dotnet publish "ThinkBridge.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://0.0.0.0:10000
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port
EXPOSE 10000

# Start the application
ENTRYPOINT ["dotnet", "ThinkBridge.dll"]
