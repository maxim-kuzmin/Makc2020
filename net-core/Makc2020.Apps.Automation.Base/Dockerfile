#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Makc2020.Apps.Automation.Base/Makc2020.Apps.Automation.Base.csproj", "Makc2020.Apps.Automation.Base/"]
COPY ["Makc2020.Root.Apps.Automation.Base/Makc2020.Root.Apps.Automation.Base.csproj", "Makc2020.Root.Apps.Automation.Base/"]
COPY ["Makc2020.Mods.Automation.Base/Makc2020.Mods.Automation.Base.csproj", "Makc2020.Mods.Automation.Base/"]
COPY ["Makc2020.Core.Base/Makc2020.Core.Base.csproj", "Makc2020.Core.Base/"]
COPY ["Makc2020.Host.Base/Makc2020.Host.Base.csproj", "Makc2020.Host.Base/"]
COPY ["Makc2020.Root.Base/Makc2020.Root.Base.csproj", "Makc2020.Root.Base/"]
RUN dotnet restore "Makc2020.Apps.Automation.Base/Makc2020.Apps.Automation.Base.csproj"
COPY . .
WORKDIR "/src/Makc2020.Apps.Automation.Base"
RUN dotnet build "Makc2020.Apps.Automation.Base.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Makc2020.Apps.Automation.Base.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Makc2020.Apps.Automation.Base.dll"]
