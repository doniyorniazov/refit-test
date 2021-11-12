#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpleUI/SimpleUI.csproj", "SimpleUI/"]
RUN dotnet restore "SimpleUI/SimpleUI.csproj"
COPY . .
WORKDIR "/src/SimpleUI"
RUN dotnet build "SimpleUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleUI.csproj" -c Release -o /app/publish

# We then get the base image for Nginx and set the 
# work directory 
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# We'll copy all the contents from wwwroot in the publish
# folder into nginx/html for nginx to serve. The destination
# should be the same as what you set in the nginx.conf.
COPY --from=publish /app/publish/wwwroot /usr/local/webapp/nginx/html
COPY /SimpleUI/nginx.conf /etc/nginx/nginx.conf