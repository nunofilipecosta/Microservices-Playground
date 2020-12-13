#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["sources/MicroservicesPlayground.EventCatalog.Api/MicroservicesPlayground.EventCatalog.Api.csproj", "sources/MicroservicesPlayground.EventCatalog.Api/"]
RUN dotnet restore "sources/MicroservicesPlayground.EventCatalog.Api/MicroservicesPlayground.EventCatalog.Api.csproj"
COPY . .
WORKDIR "/src/sources/MicroservicesPlayground.EventCatalog.Api"
RUN dotnet build "MicroservicesPlayground.EventCatalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesPlayground.EventCatalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesPlayground.EventCatalog.Api.dll"]