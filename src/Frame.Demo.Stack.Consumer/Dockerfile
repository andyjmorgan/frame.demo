#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Frame.Demo.Stack.Consumer/Frame.Demo.Stack.Consumer.csproj", "src/Frame.Demo.Stack.Consumer/"]
COPY ["src/Frame.Demo.Stack.DBContext/Frame.Demo.Stack.DBContext.csproj", "src/Frame.Demo.Stack.DBContext/"]
COPY ["src/Frame.Demo.Stack.Logging/Frame.Demo.Stack.Logging.csproj", "src/Frame.Demo.Stack.Logging/"]
COPY ["src/Frame.Demo.Stack.Messaging/Frame.Demo.Stack.Messaging.csproj", "src/Frame.Demo.Stack.Messaging/"]
RUN dotnet restore "./src/Frame.Demo.Stack.Consumer/Frame.Demo.Stack.Consumer.csproj"
COPY . .
WORKDIR "/src/src/Frame.Demo.Stack.Consumer"
RUN dotnet build "./Frame.Demo.Stack.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Frame.Demo.Stack.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frame.Demo.Stack.Consumer.dll"]