#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Makc2020.Apps.Api.Base/Makc2020.Apps.Api.Base.csproj", "Makc2020.Apps.Api.Base/"]
COPY ["Makc2020.Root.Apps.Api.Base/Makc2020.Root.Apps.Api.Base.csproj", "Makc2020.Root.Apps.Api.Base/"]
COPY ["Makc2020.Mods.DummyMain.Base/Makc2020.Mods.DummyMain.Base.csproj", "Makc2020.Mods.DummyMain.Base/"]
COPY ["Makc2020.Data.Entity/Makc2020.Data.Entity.csproj", "Makc2020.Data.Entity/"]
COPY ["Makc2020.Data.Base/Makc2020.Data.Base.csproj", "Makc2020.Data.Base/"]
COPY ["Makc2020.Core.Base/Makc2020.Core.Base.csproj", "Makc2020.Core.Base/"]
COPY ["Makc2020.Mods.Auth.Base/Makc2020.Mods.Auth.Base.csproj", "Makc2020.Mods.Auth.Base/"]
COPY ["Makc2020.Host.Base/Makc2020.Host.Base.csproj", "Makc2020.Host.Base/"]
COPY ["Makc2020.Root.Base/Makc2020.Root.Base.csproj", "Makc2020.Root.Base/"]
COPY ["Makc2020.Core.Data.Clients.SqlServer/Makc2020.Core.Data.Clients.SqlServer.csproj", "Makc2020.Core.Data.Clients.SqlServer/"]
COPY ["Makc2020.Data.Entity.Clients.SqlServer/Makc2020.Data.Entity.Clients.SqlServer.csproj", "Makc2020.Data.Entity.Clients.SqlServer/"]
RUN dotnet restore "Makc2020.Apps.Api.Base/Makc2020.Apps.Api.Base.csproj"
COPY . .
WORKDIR "/src/Makc2020.Apps.Api.Base"
RUN dotnet build "Makc2020.Apps.Api.Base.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Makc2020.Apps.Api.Base.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Makc2020.Apps.Api.Base.dll"]