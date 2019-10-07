###
### docker build . -t snake-game
### docker run -it --name snake-game snake-game
###

FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SnakeGame.csproj", "."]
RUN dotnet restore "SnakeGame.csproj"
COPY . .
WORKDIR "/src/SnakeGame"
RUN dotnet build "/src/SnakeGame.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "/src/SnakeGame.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SnakeGame.dll"]