#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Customer/Customer.Worker/Customer.Worker.csproj", "."]
RUN dotnet restore "Customer.Worker.csproj"
COPY . .
RUN dotnet build "Customer/Customer.Worker/Customer.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer/Customer.Worker/Customer.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Worker.dll"]
