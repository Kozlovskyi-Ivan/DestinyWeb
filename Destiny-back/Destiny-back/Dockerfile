#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
#EXPOSE 4000

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Destiny-back/Destiny-back.csproj", "Destiny-back/"]
RUN dotnet restore "Destiny-back/Destiny-back.csproj"
COPY . .
WORKDIR "/src/Destiny-back"
RUN dotnet build "Destiny-back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Destiny-back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#for usual
#ENTRYPOINT ["dotnet", "Destiny-back.dll"]
#for heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Destiny-back.dll