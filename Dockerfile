# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
#COPY *.sln .
COPY src/Application/Application.csproj ./src/Application/
COPY src/Domain/Domain.csproj ./src/Domain/
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY src/API/API.csproj ./src/API/
COPY src/API/players-data.json ./src/API/
# COPY Directory.Build.props ./Src
# COPY Directory.Packages.props ./Src

# .NET Core Restore
RUN dotnet restore ./src/API/API.csproj

# Copy All Files
COPY src ./src

# .NET Core Build and Publish
RUN dotnet publish ./src/API/API.csproj -c Release -o /publish 

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

# Expose ports
EXPOSE 5000
EXPOSE 443

# Setup your variables before running.
ARG MyEnv
ENV ASPNETCORE_ENVIRONMENT $MyEnv
ENV json-file-path "./players-data.json"

ENTRYPOINT ["dotnet", "API.dll"]