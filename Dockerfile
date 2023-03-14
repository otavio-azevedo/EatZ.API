# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./src/EatZ.API/EatZ.API.csproj"
RUN dotnet publish "./src/EatZ.API/EatZ.API.csproj" -c release -o /app

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS serve
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "EatZ.API.dll"]