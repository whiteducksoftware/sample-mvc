# minimized Dockerfile for a .Net Core sample Dockerfile based on the Alpine Image
# non-root requires the exposed port to be higher 1024

ARG VERSION=3.1-alpine3.12

FROM mcr.microsoft.com/dotnet/core/sdk:$VERSION AS build-env

WORKDIR /app
ADD . .
RUN dotnet publish \
  -c Release \
  -o ./output

FROM mcr.microsoft.com/dotnet/core/aspnet:$VERSION
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

