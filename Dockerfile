# BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# restore
COPY *.sln .
COPY src/AgroSolutions.Medicoes.Application/AgroSolutions.Medicoes.Application.csproj src/AgroSolutions.Medicoes.Application/
COPY src/AgroSolutions.Medicoes.Domain/AgroSolutions.Medicoes.Domain.csproj src/AgroSolutions.Medicoes.Domain/
COPY src/AgroSolutions.Medicoes.Infrastructure/AgroSolutions.Medicoes.Infrastructure.csproj src/AgroSolutions.Medicoes.Infrastructure/
COPY src/AgroSolutions.Medicoes.Worker/AgroSolutions.Medicoes.Worker.csproj src/AgroSolutions.Medicoes.Worker/
RUN dotnet restore src/AgroSolutions.Medicoes.Worker/AgroSolutions.Medicoes.Worker.csproj

#Copia o restante do código
COPY . .

# Realiza o publish em modo release
RUN dotnet publish src/AgroSolutions.Medicoes.Worker/AgroSolutions.Medicoes.Worker.csproj -c Release -o /app/publish

# RUNTIME STAGE
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Copia os arquivos publicados da etapa de build
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AgroSolutions.Medicoes.Worker.dll"]