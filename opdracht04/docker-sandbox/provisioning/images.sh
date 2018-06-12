#! /usr/bin/bash
# abort on nonzero exitstatus
set -o errexit
# abort on unbound variable
set -o nounset
# don't mask errors in piped commands
set -o pipefail

#paswoord variabele
password=Vagrant123

docker pull microsoft/mssql-server-linux

export ACCEPT_EULA=Y
export SA_PASSWORD=$password

docker run -e 'ACCEPT_EULA' -e 'SA_PASSWORD' -p 1433:1433 -d microsoft/mssql-server-linux

docker pull microsoft/dotnet:1.0.1-sdk-projectjson