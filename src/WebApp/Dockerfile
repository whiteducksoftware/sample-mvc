# minimized Dockerfile for a .Net Core sample Dockerfile based on the Alpine Image
# non-root requires the exposed port to be higher 1024

ARG VERSION=6.0-alpine3.14



FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env
ARG VERSION_FOLDER="fred-version"
WORKDIR /app

ADD ./*.csproj .
RUN dotnet restore

ADD . .
# Test if the given folder exists
RUN if [ ! -d "/app/Container-Versions/${VERSION_FOLDER}" ]; then exit 1; fi && \
    # Test if the given version folder contains a png image
    if [ -f "/app/Container-Versions/${VERSION_FOLDER}/"*.png ]; then \
    # Remove the default image
    rm /app/wwwroot/img/logo.png && \
    # Replace the default logo with the .png image from the given version folder
    mv /app/Container-Versions/"${VERSION_FOLDER}"/*.png /app/wwwroot/img; fi && \
    # Test if the given version folder contains appsettings file
    if [ -f "/app/Container-Versions/${VERSION_FOLDER}/appsettings.json" ]; then \
    # Copy the app settings from the given version folder
    cp /app/Container-Versions/"${VERSION_FOLDER}"/appsettings.json /app; fi
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
#ENTRYPOINT ["dotnet", "sample-mvc.dll"]
ENTRYPOINT ["./sample-mvc", "--urls", "http://0.0.0.0:8080"]