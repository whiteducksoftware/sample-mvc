FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

RUN adduser --disabled-password --home /app --gecos '' app \
  && chown -R app /app
USER app
WORKDIR /app
COPY /src/*.csproj ./
RUN dotnet restore
COPY /src ./
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
COPY --from=build-env /app/output .
EXPOSE 80
ENTRYPOINT ["dotnet", "sample-mvc.dll"]

