#! /usr/bin/bash
# abort on nonzero exitstatus
set -o errexit
# abort on unbound variable
set -o nounset
# don't mask errors in piped commands
set -o pipefail

cd /vagrant/sol10MvcInDepth/src/Dienstencheques/

cat > Dockerfile << EOF 
FROM microsoft/dotnet:1.0.1-sdk-projectjson

RUN mkdir -p /app

WORKDIR /app

COPY . /app

RUN dotnet restore

RUN dotnet build

EXPOSE 5000/tcp

ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "run"]
EOF

docker build -t sol10mvcindepth:myapp .

docker run -d -p 8080:5000 -t sol10mvcindepth:myapp