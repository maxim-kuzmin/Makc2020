#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Makc2020.Apps.IdentityServer.Web/Makc2020.Apps.IdentityServer.Web.csproj", "Makc2020.Apps.IdentityServer.Web/"]
COPY ["Makc2020.Root.Apps.IdentityServer.Web/Makc2020.Root.Apps.IdentityServer.Web.csproj", "Makc2020.Root.Apps.IdentityServer.Web/"]
COPY ["Makc2020.Root.Apps.IdentityServer.Base/Makc2020.Root.Apps.IdentityServer.Base.csproj", "Makc2020.Root.Apps.IdentityServer.Base/"]
COPY ["Makc2020.Mods.IdentityServer.Base/Makc2020.Mods.IdentityServer.Base.csproj", "Makc2020.Mods.IdentityServer.Base/"]
COPY ["Makc2020.Host.Base/Makc2020.Host.Base.csproj", "Makc2020.Host.Base/"]
COPY ["Makc2020.Data.Entity/Makc2020.Data.Entity.csproj", "Makc2020.Data.Entity/"]
COPY ["Makc2020.Data.Base/Makc2020.Data.Base.csproj", "Makc2020.Data.Base/"]
COPY ["Makc2020.Core.Base/Makc2020.Core.Base.csproj", "Makc2020.Core.Base/"]
COPY ["Makc2020.Root.Base/Makc2020.Root.Base.csproj", "Makc2020.Root.Base/"]
COPY ["Makc2020.Core.Data.Base.Clients.SqlServer/Makc2020.Core.Data.Base.Clients.SqlServer.csproj", "Makc2020.Core.Data.Base.Clients.SqlServer/"]
COPY ["Makc2020.Data.Entity.Clients.SqlServer/Makc2020.Data.Entity.Clients.SqlServer.csproj", "Makc2020.Data.Entity.Clients.SqlServer/"]
COPY ["Makc2020.Root.Web/Makc2020.Root.Web.csproj", "Makc2020.Root.Web/"]
COPY ["Makc2020.Mods.IdentityServer.Web/Makc2020.Mods.IdentityServer.Web.csproj", "Makc2020.Mods.IdentityServer.Web/"]
COPY ["Makc2020.Core.Web/Makc2020.Core.Web.csproj", "Makc2020.Core.Web/"]
RUN dotnet restore "Makc2020.Apps.IdentityServer.Web/Makc2020.Apps.IdentityServer.Web.csproj"
COPY . .
WORKDIR "/src/Makc2020.Apps.IdentityServer.Web"
RUN dotnet build "Makc2020.Apps.IdentityServer.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Makc2020.Apps.IdentityServer.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Makc2020.Apps.IdentityServer.Web.dll"]