FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["src/Athr.Api/Athr.Api.csproj", "src/Athr.Api/"]
COPY ["src/Athr.Application/Athr.Application.csproj", "src/Athr.Application/"]
COPY ["src/Athr.Domain/Athr.Domain.csproj", "src/Athr.Domain/"]
COPY ["src/Athr.Infrastructure/Athr.Infrastructure.csproj", "src/Athr.Infrastructure/"]
RUN dotnet restore "./src/Athr.Api/./Athr.Api.csproj"
COPY . .
WORKDIR "/src/src/Athr.Api"
RUN dotnet build "./Athr.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Athr.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#RUN chmod 644 /app/.aspnet/https/Athr.Api.pfx
ENTRYPOINT ["dotnet", "Athr.Api.dll"]