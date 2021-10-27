FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CheckInputValueConsole/CheckInputValueConsole.csproj", "CheckInputValueConsole/"]
RUN dotnet restore "CheckInputValueConsole/CheckInputValueConsole.csproj"
COPY . .
WORKDIR "/src/CheckInputValueConsole"
RUN dotnet build "CheckInputValueConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckInputValueConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckInputValueConsole.dll"]
