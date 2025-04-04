# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ambev.DeveloperEvaluation.Api/Ambev.DeveloperEvaluation.Api.csproj", "Ambev.DeveloperEvaluation.Api/"]
COPY ["Ambev.DeveloperEvaluation.Application/Ambev.DeveloperEvaluation.Application.csproj", "Ambev.DeveloperEvaluation.Application/"]
COPY ["Ambev.DeveloperEvaluation.Common/Ambev.DeveloperEvaluation.Common.csproj", "Ambev.DeveloperEvaluation.Common/"]
COPY ["Ambev.DeveloperEvaluation.Entities/Ambev.DeveloperEvaluation.Entity.csproj", "Ambev.DeveloperEvaluation.Entities/"]
COPY ["Ambev.DeveloperEvaluation.UoW/Ambev.DeveloperEvaluation.UoW.csproj", "Ambev.DeveloperEvaluation.UoW/"]
COPY ["Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation.ORM.csproj", "Ambev.DeveloperEvaluation.ORM/"]
COPY ["Ambev.DeveoperEvaluation.IoC/Ambev.DeveoperEvaluation.IoC.csproj", "Ambev.DeveoperEvaluation.IoC/"]
RUN dotnet restore "./Ambev.DeveloperEvaluation.Api/Ambev.DeveloperEvaluation.Api.csproj"
COPY . .
WORKDIR "/src/Ambev.DeveloperEvaluation.Api"
RUN dotnet build "./Ambev.DeveloperEvaluation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ambev.DeveloperEvaluation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ambev.DeveloperEvaluation.Api.dll"]