FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ElectricBike.Web/ElectricBike.Web.csproj", "ElectricBike.Web/"]
RUN dotnet restore "ElectricBike.Web/ElectricBike.Web.csproj"
COPY . .
WORKDIR "/src/ElectricBike.Web"
RUN dotnet build "ElectricBike.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElectricBike.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectricBike.Web.dll"]
