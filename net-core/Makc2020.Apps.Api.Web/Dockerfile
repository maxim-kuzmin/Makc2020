#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Makc2020.Apps.Api.Web/Makc2020.Apps.Api.Web.csproj", "Makc2020.Apps.Api.Web/"]
COPY ["Makc2020.Root.Apps.Api.Web/Makc2020.Root.Apps.Api.Web.csproj", "Makc2020.Root.Apps.Api.Web/"]
COPY ["Makc2020.Data.Caching/Makc2020.Data.Caching.csproj", "Makc2020.Data.Caching/"]
COPY ["Makc2020.Data.Base/Makc2020.Data.Base.csproj", "Makc2020.Data.Base/"]
COPY ["Makc2020.Core.Base/Makc2020.Core.Base.csproj", "Makc2020.Core.Base/"]
COPY ["Makc2020.Core.Caching/Makc2020.Core.Caching.csproj", "Makc2020.Core.Caching/"]
COPY ["Makc2020.Root.Web/Makc2020.Root.Web.csproj", "Makc2020.Root.Web/"]
COPY ["Makc2020.Host.Web/Makc2020.Host.Web.csproj", "Makc2020.Host.Web/"]
COPY ["Makc2020.Core.Web/Makc2020.Core.Web.csproj", "Makc2020.Core.Web/"]
COPY ["Makc2020.Host.Base/Makc2020.Host.Base.csproj", "Makc2020.Host.Base/"]
COPY ["Makc2020.Data.Entity/Makc2020.Data.Entity.csproj", "Makc2020.Data.Entity/"]
COPY ["Makc2020.Root.Base/Makc2020.Root.Base.csproj", "Makc2020.Root.Base/"]
COPY ["Makc2020.Core.Data.SqlServer/Makc2020.Core.Data.SqlServer.csproj", "Makc2020.Core.Data.SqlServer/"]
COPY ["Makc2020.Data.Entity.SqlServer/Makc2020.Data.Entity.SqlServer.csproj", "Makc2020.Data.Entity.SqlServer/"]
COPY ["Makc2020.Mods.Auth.Web/Makc2020.Mods.Auth.Web.csproj", "Makc2020.Mods.Auth.Web/"]
COPY ["Makc2020.Mods.Auth.Base/Makc2020.Mods.Auth.Base.csproj", "Makc2020.Mods.Auth.Base/"]
COPY ["Makc2020.Root.Apps.Api.Base/Makc2020.Root.Apps.Api.Base.csproj", "Makc2020.Root.Apps.Api.Base/"]
COPY ["Makc2020.Mods.DummyMain.Base/Makc2020.Mods.DummyMain.Base.csproj", "Makc2020.Mods.DummyMain.Base/"]
COPY ["Makc2020.Mods.DummyMain.Web/Makc2020.Mods.DummyMain.Web.csproj", "Makc2020.Mods.DummyMain.Web/"]
COPY ["Makc2020.Mods.DummyMain.Caching/Makc2020.Mods.DummyMain.Caching.csproj", "Makc2020.Mods.DummyMain.Caching/"]
RUN dotnet restore "Makc2020.Apps.Api.Web/Makc2020.Apps.Api.Web.csproj"
COPY . .
WORKDIR "/src/Makc2020.Apps.Api.Web"
RUN dotnet build "Makc2020.Apps.Api.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Makc2020.Apps.Api.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Makc2020.Apps.Api.Web.dll"]