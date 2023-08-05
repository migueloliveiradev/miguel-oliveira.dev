#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["migueloliveiradev/migueloliveiradev.csproj", "migueloliveiradev/"]
RUN dotnet restore "migueloliveiradev/migueloliveiradev.csproj"
COPY . .
WORKDIR "/src/migueloliveiradev"
RUN dotnet build "migueloliveiradev.csproj" -c Release -o /app/build

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "migueloliveiradev.csproj" -c Release -o /app/publish


# Install the agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
    && echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
    && wget https://download.newrelic.com/548C16BF.gpg \
    && apt-key add 548C16BF.gpg \
    && apt-get update \
    && apt-get install -y 'newrelic-dotnet-agent' \
    && rm -rf /var/lib/apt/lists/*

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "migueloliveiradev.dll"]