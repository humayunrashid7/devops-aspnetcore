# Build stage: restore, compile, and publish the application.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DevOpsApi.csproj .
RUN dotnet restore DevOpsApi.csproj

COPY . .
RUN dotnet publish DevOpsApi.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage: run the published app on the lighter ASP.NET runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DevOpsApi.dll"]
