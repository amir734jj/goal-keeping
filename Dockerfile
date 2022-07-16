FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .

WORKDIR "/app/Api"

RUN dotnet restore
RUN dotnet publish -c Release -o out

WORKDIR "/app/UI"

RUN dotnet restore
RUN dotnet publish -c Release -o out

COPY app/UI/out/wwwroot /app/Api/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

RUN apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib && \
    apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted

WORKDIR /app
COPY --from=build-env "/app/Api/out" .
ENTRYPOINT ["dotnet", "API.dll"]