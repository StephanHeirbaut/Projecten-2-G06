# Testplan : Docker

## Installatie Docker-sandbox
Installeer als eerste de Docker-sandbox in je directory naar keuze door hierin een Git Bash console te openen en het volgende commando uit te voeren.

    git clone https://github.com/bertvv/docker-sandbox

Nadat dit gebeurt is kun je de Docker-sandbox installeren door in deze geclonede directory te gaan, en in dezelfde directory met het Vagrantfile het volgende commando uit te voeren in een bash console

    cd docker-sandbox
    vagrant up
    
## MSSQL server installeren
Hierna gaan we een databank opzetten voor de applicatie, als dit niet nodig is kun je dit overslaan.

    vagrant ssh

    docker pull microsoft/mssql-server-linux
       
    export ACCEPT_EULA=Y
    export SA_PASSWORD=your_strong_password_here
    
    docker run -e 'ACCEPT_EULA' -e 'SA_PASSWORD' -p 1433:1433 -d microsoft/mssql-server-linux
    
Ga vervolgens naar 192.168.56.12:9090, dit zal je leiden naar Cockpit.
Als de link niet werkt, kan het zijn Cockpit niet correct is opgestart.
Om dit te fixen voer je gewoon het volgende uit in de bash console

    systemctl start cockpit

Met Cockpit heb je een GUI om te kijken naar alle containers en images die er beschikbaar zijn.
Ga hiervoor naar 'Containers' en klik op 'docker.io/microsoft/mssql-server-linux:latest'-image.
Klik vervolgens op de container en zoek naar het ip-adres.
Deze zul je nodig hebben voor de connectionstring.

## .NET project klaar zetten
Zodra de installatie is afgerond, clone of kopieer je best eerst de folder met je .NET-project erin in dezelfde folder als het Vagrantfile.

    git clone https://github.com/WebIII/sol10MvcInDepth.git
    of cp projectFolderNaam /vagrant

Je gaat ook nog de connectionstring moeten aanpassen in het project dat staat in appsettings.project.
Je zal de user en wachtwoord moeten toevoegen. Alsook het ipadres van de server invoeren en de trusted connection op false zetten.

    "DefaultConnection": "Server=172.17.0.3;Database=DienstenCheques;User=sa;Password=Vagrant123;Trusted_Connection=False;"

## Installeren .NET-applicaties
Daarna, als de box geïnstalleerd en de projectfolder erin staat kun je met het volgende commando in de machine kruipen vanuit een bash console:

    vagrant ssh
    
Hierna zul je in je bash console in de Docker-sandbox zitten.

Als klein experiment kun je het volgende project eens proberen maken met de volgende commando's:

    docker pull microsoft/dotnet
    docker run microsoft/dotnet-samples

Voer vervolgens het volgende commando uit om in de projectfolder te komen.

    cd /vagrant/sol10MvcInDepth/src/Dienstencheques/
    *pro-tip: gebruik tab om te auto-completen
    
Pull vervolgens de SDK image met

    docker pull microsoft/dotnet:1.0.1-sdk-projectjson

Hierna maak je deze directory, dezelfde waarin je project.json hoort te staan, een nieuwe bestand aan met als naam 'Dockerfile'.
Je kunt dit best doen met

    vi Dockerfile

In dit bestand zet je dan de volgende zinnen:

    FROM microsoft/dotnet:1.0.1-sdk-projectjson

    RUN mkdir -p /app

    WORKDIR /app

    COPY . /app

    RUN dotnet restore

    RUN dotnet build

    EXPOSE 5000/tcp

    ENV ASPNETCORE_URLS http://*:5000
    
    ENTRYPOINT ["dotnet", "run"]
    
Als dit allemaal gebeurt is moet je alleen nog de volgende commando's uitvoeren (in deze volgorde):

    docker build -t sol10mvcindepth:myapp .
  
    docker run -d -p 8080:5000 -t sol10mvcindepth:myapp
  
## Bekijken images, containers en applicaties
Vervolgens kun je surfen naar 192.168.56.12:9090 (Cockpit) en je inloggen met Vagrant - Vagrant om je images en containers te bekijken.
Als je voor de 2de keer je systeem opstart met 'vagrant up', kan het zijn dat Cockpit niet mee opstart.
Dit kun je zien door

    Systemctl status cockpit

Uit te voeren
Als de service uitstaat kun je deze opstarten met

    systemctl start cockpit

Als er een probleem zou voorgetreden zijn in de applicatie zul je in de console van de containers de errors en exceptions kunnen zien.
Maar, als alles goed is gegaan zullen ze hier staan draaien en kun je ermee verbinding maken met 192.168.56.12:8080.

Auteur testplan: Stephan Heirbaut
