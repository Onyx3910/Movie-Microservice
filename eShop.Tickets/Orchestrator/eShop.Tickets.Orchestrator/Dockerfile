FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eShop.Tickets.Orchestrator.csproj", "eShop.Tickets.Orchestrator/"]
RUN dotnet restore "eShop.Tickets.Orchestrator/eShop.Tickets.Orchestrator.csproj"

COPY . eShop.Tickets.Orchestrator/.
RUN dotnet publish -c Release -o /app eShop.Tickets.Orchestrator/eShop.Tickets.Orchestrator.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "eShop.Tickets.Orchestrator.dll"]