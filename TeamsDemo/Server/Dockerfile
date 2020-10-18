#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TeamsDemo/Server/TeamsDemo.Server.csproj", "TeamsDemo/Server/"]
COPY ["TeamsDemo/Shared/TeamsDemo.Shared.csproj", "TeamsDemo/Shared/"]
COPY ["TeamsDemo/Client/TeamsDemo.Client.csproj", "TeamsDemo/Client/"]
RUN dotnet restore "TeamsDemo/Server/TeamsDemo.Server.csproj"
COPY . .
WORKDIR "/src/TeamsDemo/Server"
RUN dotnet build "TeamsDemo.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamsDemo.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamsDemo.Server.dll"]