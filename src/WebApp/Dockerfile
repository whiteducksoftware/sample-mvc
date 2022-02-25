# minimized Dockerfile for a .Net Core sample Dockerfile based on the Alpine Image
# non-root requires the exposed port to be higher 1024

ARG VERSION=6.0-alpine3.14

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env

ARG VERSION_FOLDER="fred-version"

WORKDIR /app
ADD . .
# Test if the given folder exists
RUN if [ ! -d "/app/Container-Versions/${VERSION_FOLDER}" ]; then exit 1; fi && \
    # Copy a .png image from the given version folder
    cp /app/Container-Versions/"${VERSION_FOLDER}"/*.png /app/wwwroot/img/logo.png && \
    # Copy the app settings from the given version folder
    cp /app/Container-Versions/"${VERSION_FOLDER}"/appsettings.json /app
RUN dotnet publish \
  -c Release \
  -o ./output

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
RUN adduser \
  --disabled-password \
  --home /app \
  --gecos '' app \
  && chown -R app /app
USER app
WORKDIR /app
COPY --from=build-env /app/output .
ENV DOTNET_RUNNING_IN_CONTAINER=true \
  ASPNETCORE_URLS=http://+:8080

EXPOSE 8080
ENTRYPOINT ["dotnet", "sample-mvc.dll"]

