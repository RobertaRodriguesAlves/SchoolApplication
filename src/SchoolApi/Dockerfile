#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SchoolApi/SchoolApi.csproj", "SchoolApi/"]
COPY ["Infrastructure/Repositories/Repositories.csproj", "Infrastructure/Repositories/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Core/Services.Abstractions/Services.Abstractions.csproj", "Core/Services.Abstractions/"]
COPY ["Core/Contracts/Contracts.csproj", "Core/Contracts/"]
COPY ["Core/Services/Services.csproj", "Core/Services/"]
COPY ["Infrastructure/Presentation/Presentation.csproj", "Infrastructure/Presentation/"]
RUN dotnet restore "SchoolApi/SchoolApi.csproj"
COPY . .
WORKDIR "/src/SchoolApi"
RUN dotnet build "SchoolApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolApi.dll"]