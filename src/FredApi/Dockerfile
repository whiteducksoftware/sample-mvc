# minimized Dockerfile for a .Net Core sample Dockerfile based on the Alpine Image
# non-root requires the exposed port to be higher 1024

ARG VERSION=6.0-alpine3.14



FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env

WORKDIR /app

ADD FredApi/*.csproj .
RUN dotnet restore

ADD FredApi/ .
RUN dotnet publish \
  --runtime alpine-x64 \
  --self-contained true \
  /p:PublishTrimmed=true \
  /p:PublishSingleFile=true \
  -c Release \
  -o ./output



#FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
FROM mcr.microsoft.com/dotnet/runtime-deps:$VERSION
RUN adduser \
  --disabled-password \
  --home /app \
  --gecos '' app \
  && chown -R app /app
USER app
WORKDIR /app
COPY --from=build-env /app/output .
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1 \
  DOTNET_RUNNING_IN_CONTAINER=true \
  ASPNETCORE_URLS=http://+:8080

EXPOSE 8080
#ENTRYPOINT ["dotnet", "FredApi.dll"]
ENTRYPOINT ["./FredApi", "--urls", "http://0.0.0.0:8080"]

