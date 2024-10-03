#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Frontliners.Assignment.Api/Frontliners.Assignment.Api.csproj", "src/Frontliners.Assignment.Api/"]
COPY ["src/Frontliners.Assignment.Application/Frontliners.Assignment.Application.csproj", "src/Frontliners.Assignment.Application/"]
COPY ["src/Frontliners.Assignment.Domain/Frontliners.Assignment.Domain.csproj", "src/Frontliners.Assignment.Domain/"]
COPY ["src/Frontliners.Assignment.Infrastructure/Frontliners.Assignment.Infrastructure.csproj", "src/Frontliners.Assignment.Infrastructure/"]
RUN dotnet restore "./src/Frontliners.Assignment.Api/./Frontliners.Assignment.Api.csproj"
COPY . .
WORKDIR "/src/src/Frontliners.Assignment.Api"
RUN dotnet build "./Frontliners.Assignment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Frontliners.Assignment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontliners.Assignment.Api.dll"]