#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-1903 AS build
WORKDIR /src
COPY ["QuickMVCTestApp/QuickMVCTestApp.csproj", "QuickMVCTestApp/"]
RUN dotnet restore "QuickMVCTestApp/QuickMVCTestApp.csproj"
COPY . .
WORKDIR "/src/QuickMVCTestApp"
RUN dotnet build "QuickMVCTestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuickMVCTestApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuickMVCTestApp.dll"]