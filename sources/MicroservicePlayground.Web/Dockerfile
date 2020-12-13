#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["sources/MicroservicePlayground.Web/MicroservicePlayground.Web.csproj", "sources/MicroservicePlayground.Web/"]
RUN dotnet restore "sources/MicroservicePlayground.Web/MicroservicePlayground.Web.csproj"
COPY . .
WORKDIR "/src/sources/MicroservicePlayground.Web"
RUN dotnet build "MicroservicePlayground.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicePlayground.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicePlayground.Web.dll"]