FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore UsersTasks.csproj

COPY . ./
RUN dotnet publish UsersTasks.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "UsersTasks.dll"]`