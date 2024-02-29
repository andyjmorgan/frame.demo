FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Frame.Demo.Stack.TemperatureProbe/Frame.Demo.Stack.TemperatureProbe.csproj", "Frame.Demo.Stack.TemperatureProbe/"]
RUN dotnet restore "Frame.Demo.Stack.TemperatureProbe/Frame.Demo.Stack.TemperatureProbe.csproj"
COPY . .
WORKDIR "/src/Frame.Demo.Stack.TemperatureProbe"
RUN dotnet build "Frame.Demo.Stack.TemperatureProbe.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Frame.Demo.Stack.TemperatureProbe.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frame.Demo.Stack.TemperatureProbe.dll"]
