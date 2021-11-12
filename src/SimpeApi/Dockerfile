FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpeApi/SimpleApi.csproj", "SimpeApi/"]
RUN dotnet restore "SimpeApi/SimpleApi.csproj"
COPY . .
WORKDIR "/src/SimpeApi"
RUN dotnet build "SimpleApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleApi.dll"]
