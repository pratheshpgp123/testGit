#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DSvNxt.Poc.Supplier_DbApi_Kraken.csproj", ""]
RUN dotnet restore "./DSvNxt.Poc.Supplier_DbApi_Kraken.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DSvNxt.Poc.Supplier_DbApi_Kraken.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSvNxt.Poc.Supplier_DbApi_Kraken.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSvNxt.Poc.Supplier_DbApi_Kraken.dll"]