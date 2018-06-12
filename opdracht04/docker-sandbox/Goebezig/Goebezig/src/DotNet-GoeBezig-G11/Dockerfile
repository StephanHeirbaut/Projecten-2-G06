FROM microsoft/dotnet:1.0.1-sdk-projectjson

RUN mkdir -p /app

WORKDIR /app

COPY . /app

RUN dotnet restore

RUN dotnet build

EXPOSE 5000/tcp

ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "run"]
