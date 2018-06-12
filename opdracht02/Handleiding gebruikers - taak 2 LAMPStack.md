# Handleiding gebruikers: LAMP Stack 

Voor de LAMP stack hebben we gekozen voor gebruik te maken van CentOS core installatie, omdat we hiermee al ervaring hadden en omdat dit de performantie te goede komt.
Verder werd hebben we er ook Apache, MariaDB en PHP op geïnstalleerd. Zodat de gebruiker er een databank en een webapplicatie erop kon zetten.

## Part 1: Installatie nodige software  

  **Vagrant installeren**
    
 Vagrant gebruiken we om de scripts te laten uit te voeren en een virtuele machine te generen.
 Je kan vagrant downloaden met de volgende link: https://www.vagrantup.com/downloads.html 
 
 **Virtual box installeren** 
  Virtual box hebben we nodig voor een virtuele machine te kunnen laten generen door vagrant. 
  Deze kan je downloaden met de volgende link: https://www.virtualbox.org/wiki/Downloads. 
    
  **Git installeren** 
  Om de files te gebruiken die op GitHub staan. Moet je natuurlijk ook eerst git installeren op je locale machine. 
  Deze kan je downloaden met de volgende link: https://git-scm.com/downloads
  
## Part 2: Git lokaal zetten 
  
Eerst gaan we de files die nodig zijn lokaal zetten. Je opent in de map waar je deze bestanden wilt clonen een Git Bash instantie openen door in deze directory te rechterklikken en op 'Git Bash Here' te drukken. 

![git bash](https://cloud.githubusercontent.com/assets/17174277/25130058/15584c70-2441-11e7-819c-e0c2ca0ea631.png)

Dan krijg je het volgende scherm: 

![Gitbash_open](https://cloud.githubusercontent.com/assets/17159222/24856928/b13fb102-1de6-11e7-8d1e-473d51f13929.png)
    
Hierin voer je dan het volgende commando:

    git clone https://github.com/HoGentTIN/p2ops-g06-1.git
    
Als alles goed gaat zul je nu een lokale instantie hebben van deze bestanden. Ga nu in deze nieuw gecreëerde directory en open de LAMP stack directory.

## Part 3: Database initializeren

Standaard zal er al een gebruikeraccount geconfigureerd worden voor de databank.
De configuratie hiervan staat definieerd in de variabelen die bovenaan staan gedefinieert in het bestand 'scriptLAMPstack.sh'.
Als je liever een andere naam/paswoord wilt gebruiken, moet je alleen maar de tekst na de '=' aan te passen naar eigen smaak.

Bijvoorbeeld:

    user='vagrant'
    password='vagrant'
    databaseName='testapp'
    mysqlRootPass='TestApp95'
    
Kun je wijzigen naar:

    user='janssens'
    password='J4nss3ns'
    databaseName='janssens'
    mysqlRootPass='Janssens2017!'
    
In het bestand 'testappscript.sh' zal de databank dan effectief geïnitaliseerd worden. Als je dit wilt personaliseren kun je dit best doen door je eigen SQL zetten tussen de lijnen:

    mysql -uroot -p${mysqlRootPass} << EOF
    
En

    EOF
    
Voor de connectie met de databank maken we gebruik van het 'wp-config.php' bestand in de lokale folder. Deze wordt meegegeven bij de installatie van de server en zorgt voor de configuratie van de verbinding.
Als de gebruiker de instellingen van de verbinding wil personaliseren kan dit, door de volgende stappen te volgen:

1. Open het bestand met notepad, brackets of een andere teksteditor
2. Editeer de volgende lijnen, maar lees aandacht de commentaar, deze zal alles verduidelijk wat er waar zal moeten staan:![dbconnectie](https://cloud.githubusercontent.com/assets/17174539/24878349/15f80a1c-1e33-11e7-8d9d-247d00f6f21b.png)

## Part 4: Installatie webapplicatieplatform

Om nu de server lokaal te installeren moet je in de LAMPstack directory zitten en hierin moet je dan het volgende commando uitvoeren waardoor je server en databank geïnstalleerd zullen worden.
Dit kun je doen door een Git Bash instantie te starten net zoals we gaan hebben in Part 1.
Maar, in plaats van 'git clone' uit te voeren, voer je de volgende commando's uit.

    cd  p2ops-g06-1/opdracht02/LAMPstack/
    vagrant up

Hierna zal de installatie beginnen, vanuit dezelfde console kun je met het volgende commando remote een verbinding aangaan wanneer de installatie gedaan is.  

    vagrant ssh

## Part 5: Webapplicatie starten/testen

Om de applicatie te starten surf je naar de site
https://http://192.168.56.10/

Dit zal je naar de inlogpagina van de applicatie brengen.

Auteur(s): Stephan Heirbaut
