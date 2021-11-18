FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY Origin.Take.Home.Assignment/Origin.Take.Home.Assignment.csproj Origin.Take.Home.Assignment/
COPY nuget.config ./
RUN dotnet restore ./Origin.Take.Home.Assignment/Origin.Take.Home.Assignment.csproj

COPY . .
RUN dotnet publish Origin.Take.Home.Assignment/Origin.Take.Home.Assignment.csproj -c Release -o out

# # final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Origin.Take.Home.Assignment.dll"]