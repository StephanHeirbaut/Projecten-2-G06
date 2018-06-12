## Docker  
### Cockpit
Docker start goed op doormiddel van Vagrant up.  
Maar, Cockpit niet. Te fixen door bij het opstarten
        
        systemctl start cockpit
        
uit te voeren.  

### docker build error
MSBUILD error opgelost. Er wordt niet langer gewerkt met project.json.

        Note: The latest tag no longer uses the project.json project format, but has now been updated to be csproj/MSBuild-based.  
        If you do not wish to migrate your existing projects to MSBuild simply change your Dockerfile to use the 1.1.0-sdk-projectjson  
        or 1.1.0-sdk-projectjson-nanoserver tag. Going forward, new .NET Core sdk images will be MSBuild-based.
        
Oplossing:
                
                docker pull microsoft/dotnet:1.0.1-sdk-projectjson
                
### MSSQL

Voor de installatie van de MSSQL server moet je enviroment variabelen aanmaken.
Hiervoor heb je het volgende commando nodig:

        export variabeleNaam = variabeleWaarde
        
In appsettings.json de connectionstring nog aanpassen?
Lijntje uit commentaar halen.
Uitleg aan mr Van Vreckem/Jochem vragen.

### Build and run an application with a .NET Core SDK Image  

Om hiermee te werken moet je de packages npm, bower en gulp installeren, met admin rechten, in deze volgorde met:
* yum install npm -y 
* npm install -g bower  
* npm install -g gulp  

Dockerfile:
        
        FROM microsoft/dotnet:1.0.1-sdk-projectjson

        RUN mkdir -p /app

        WORKDIR /app

        COPY . /app

        RUN dotnet restore

        RUN dotnet build

        EXPOSE 5000/tcp

        ENV ASPNETCORE_URLS http://*:5000
        
        ENTRYPOINT ["dotnet", "run"]

        
https://stormpath.com/blog/tutorial-deploy-asp-net-core-on-linux-with-docker


Info:  
* https://docs.docker.com/engine/reference/builder/
* https://docs.docker.com/engine/reference/commandline/build/
* https://hub.docker.com/r/microsoft/dotnet/
* https://hub.docker.com/r/microsoft/mssql-server-linux/
* https://www.microsoft.com/net/core#dockercmd
