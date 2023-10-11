FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TripSupp.WebAPI.csproj", "./"]
RUN dotnet restore "TripSupp.WebAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TripSupp.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TripSupp.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TripSupp.WebAPI.dll"]

