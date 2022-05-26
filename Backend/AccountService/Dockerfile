#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/AccountService/AccountService.Microservice.csproj", "AccountService/"]
COPY ["Backend/AccountService/appsettings.json", "AccountService/"]
RUN dotnet restore "AccountService/AccountService.Microservice.csproj"
COPY . .
WORKDIR "/src/AccountService"
COPY Backend/AccountService ./AccountService
RUN dotnet build "AccountService.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountService.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountService.Microservice.dll"]