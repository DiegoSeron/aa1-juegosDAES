FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish "Juegos.csproj" -c Release -o /consoleapp

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /application
COPY --from=build /consoleapp ./
ENTRYPOINT ["dotnet", "Juegos.dll"]

EXPOSE 24589
VOLUME /archivos