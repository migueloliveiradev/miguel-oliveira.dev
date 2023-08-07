FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app

COPY . .
RUN dotnet restore "migueloliveiradev.csproj"

RUN dotnet build "migueloliveiradev.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "migueloliveiradev.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

# Install the agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
    && echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
    && wget https://download.newrelic.com/548C16BF.gpg \
    && apt-key add 548C16BF.gpg \
    && apt-get update \
    && apt-get install -y 'newrelic-dotnet-agent' \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "migueloliveiradev.dll"]