#Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./RecipeApp_RecipeAPI/RecipeApp_RecipeAPI.csproj" --disable-parallel
RUN dotnet publish "./RecipeApp_RecipeAPI/RecipeApp_RecipeAPI.csproj" -c release -o /app --no-restore

#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "RecipeApp_RecipeAPI.dll"]
