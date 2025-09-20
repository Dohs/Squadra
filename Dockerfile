# Étape 1: Base pour WebApi - Utilise l'image runtime ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base-webapi
WORKDIR /app
EXPOSE 8080

# Étape 2: Build - Utilise l'image SDK pour construire les projets
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

# Construire les projets
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build/webapi

WORKDIR "/src/Squadra.UI"
RUN dotnet build "Squadra.UI.csproj" -c Release -o /app/build/squadra-ui

# Étape 3: Publish - Publier les applications
FROM build AS publish
WORKDIR "/src/WebApi"
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish/webapi /p:UseAppHost=false

WORKDIR "/src/Squadra.UI"
RUN dotnet publish "Squadra.UI.csproj" -c Release -o /app/publish/squadra-ui

# Étape 4: Final pour WebApi - Créer l'image finale pour WebApi
FROM base-webapi AS squadra-webapi
WORKDIR /app
COPY --from=publish /app/publish/webapi .
ENTRYPOINT ["dotnet", "WebApi.dll"]

# Étape 5: Final pour Squadra.UI - Utiliser Nginx pour servir les fichiers statiques de Blazor WebAssembly
FROM nginx:1.27-alpine AS squadra-ui
COPY --from=publish /app/publish/squadra-ui/wwwroot /usr/share/nginx/html
# Copier la configuration Nginx dans le répertoire conf.d pour qu'elle soit incluse par le fichier principal
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80