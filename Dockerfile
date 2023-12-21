#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Infrastructer/Infrastructer.csproj", "Infrastructer/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["espserver/espserver.csproj", "espserver/"]

RUN dotnet restore "espserver/espserver.csproj"
COPY . .
WORKDIR "/src/espserver"
RUN dotnet build "espserver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "espserver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "espserver.dll"]