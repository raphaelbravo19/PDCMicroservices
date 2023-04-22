FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Establece el directorio de trabajo
WORKDIR /app
RUN mkdir StoresApi
RUN mkdir CorePDC
# Copia los archivos de la aplicación al directorio de trabajo
COPY ./StoresApi/StoresApi.csproj ./StoresApi/
COPY ./CorePDC/CorePDC.csproj  ./CorePDC/

WORKDIR /app/StoresApi

# Restaura las dependencias

RUN dotnet restore

WORKDIR /app

COPY ./StoresApi ./StoresApi
COPY ./CorePDC ./CorePDC

WORKDIR /app/StoresApi

FROM build-env AS publish

# Compila la aplicación
RUN dotnet publish StoresApi.csproj -c Release -o /app/publish

# Crea la imagen de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/publish .

# Expone el puerto en el que se ejecutará la aplicación
EXPOSE 80

# Inicia la aplicación
ENTRYPOINT ["dotnet", "StoresApi.dll"]