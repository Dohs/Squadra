# Étape 1: Base - Utilise l'image runtime ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Étape 2: Build - Utilise l'image SDK pour construire le projet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Installer l'outil EF Core et l'ajouter au PATH
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copier les fichiers projet et la solution, puis restaurer les dépendances
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["WebApi.Tests/WebApi.Tests.csproj", "WebApi.Tests/"]
COPY ["Squadra.UI/Squadra.UI.csproj", "Squadra.UI/"]

COPY ["projet.sln", "."]
RUN dotnet restore "./projet.sln"

# Copier tout le reste du code source
COPY . .

# Construire le projet principal
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

WORKDIR "/src/Squadra.UI"
RUN dotnet build "Squadra.UI.csproj" -c Release -o /app/build

# Étape 3: Publish - Publier l'application
FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS publish
RUN dotnet publish "Squadra.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false


# Étape 4: Final - Créer l'image finale à partir de l'image de publication (qui contient le SDK)
FROM publish AS final
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "WebApi.dll"]

