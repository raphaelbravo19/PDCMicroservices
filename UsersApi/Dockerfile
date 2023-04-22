FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Establece el directorio de trabajo
WORKDIR /app
RUN mkdir UsersApi
RUN mkdir CorePDC
# Copia los archivos de la aplicación al directorio de trabajo
COPY ./UsersApi/UsersApi.csproj ./UsersApi/
COPY ./CorePDC/CorePDC.csproj  ./CorePDC/

WORKDIR /app/UsersApi

# Restaura las dependencias

RUN dotnet restore

WORKDIR /app

COPY ./UsersApi ./UsersApi
COPY ./CorePDC ./CorePDC

WORKDIR /app/UsersApi

FROM build-env AS publish

# Compila la aplicación
RUN dotnet publish UsersApi.csproj -c Release -o /app/publish

# Crea la imagen de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/publish .

# Expone el puerto en el que se ejecutará la aplicación
EXPOSE 80

# Inicia la aplicación
ENTRYPOINT ["dotnet", "UsersApi.dll"]