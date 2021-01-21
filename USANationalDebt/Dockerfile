#Get SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build 
WORKDIR /src

COPY USANationalDebt.csproj .

RUN dotnet restore USANationalDebt.csproj

COPY . .
RUN dotnet build USANationalDebt.csproj -c Release -o /build

FROM build AS publish
RUN dotnet publish USANationalDebt.csproj -c Release -o /publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /publish/wwwroot /usr/local/webapp/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf