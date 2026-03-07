# Use the official .NET 8 runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["src/GRTAssist.API/GRTAssist.API.csproj", "GRTAssist.API/"]
RUN dotnet restore "GRTAssist.API/GRTAssist.API.csproj"

# Copy the rest of the source code
COPY ["src/GRTAssist.API/", "GRTAssist.API/"]

# Build the application
WORKDIR "/src/GRTAssist.API"
RUN dotnet build "GRTAssist.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "GRTAssist.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: copy the published app to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GRTAssist.API.dll"]