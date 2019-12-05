FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

RUN adduser --disabled-password --home /app --gecos '' app \
  && chown -R app /app
USER app
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
COPY --from=build-env /app/output .
EXPOSE 80
ENTRYPOINT ["dotnet", "sample-mvc.dll"]

