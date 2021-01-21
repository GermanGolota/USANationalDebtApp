#Get SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env 
WORKDIR /src

#Copy API project
COPY DebtAPI/DebtAPI.csproj API/
#Restore nuget packages
RUN dotnet restore API/DebtAPI.csproj
#Copy the rest of the files of API project
COPY DebtAPI/ API/
#Copy dependent project
COPY Core Core/
COPY DataAccessLibrary DataAccessLibrary/
#Build the project
RUN dotnet build API/DebtAPI.csproj
#Publish
RUN dotnet publish -c Release API/DebtAPI.csproj -o out
#Generate runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /src
ENV ASPNETCORE_ENVIROMENT=Production
EXPOSE 5001
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5001;https://+:5000   
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "DebtAPI.dll"]
