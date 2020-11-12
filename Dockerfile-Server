#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Docker.Demo.Server/Docker.Demo.Server.csproj", "Docker.Demo.Server/"]
RUN dotnet restore "Docker.Demo.Server/Docker.Demo.Server.csproj"
COPY . .
WORKDIR "/src/Docker.Demo.Server"
RUN dotnet build "Docker.Demo.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker.Demo.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker.Demo.Server.dll"]