FROM mcr.microsoft.com/dotnet/sdk:8.0 as builder
COPY . /src
WORKDIR /src
