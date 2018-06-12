# InstallatieProcedure taak 2: LAMPStack  

## Part 1: Installatie nodige software  

    a. Vagrant installeren
    Vagrant gebruiken we om de scripts te laten uit te voeren en een virtuele machine te generen.
    Je kan vagrant downloaden met de volgende link: https://www.vagrantup.com/downloads.html 
 
    b. Virtual box installeren 
    Virtual box hebben we nodig voor een virutele machine te kunnen laten generen door vagrant. 
    Deze kan je downloaden met de volgende link: https://www.virtualbox.org/wiki/Downloads. 
 
## Part 2: Script uitleg 

In het vagrantfile-bestand staat er:  
Welke basebox we gebruiken  

    config.vm.box = "bertvv/centos72"
    
Wat het ip-adres van deze box moet worden  

    config.vm.network "private_network", ip: "192.168.56.11"
    
En, welke provisioningscripts er uit gevoerd zullen worden. Opgesplitst in de installatie van het platform en de applicaties 

    config.vm.provision :shell, path: "scriptJAVAEEstack.sh" 
    
En, de initialisatie van de databank  

    config.vm.provision :shell, path: "testappscript.sh" 
    
We hebben geen omgeving gedefinieert, omdat deze standaard al VirtualBox is. Maar, er zijn andere providers mogelijk.  

Als je het eerste provisioningscripts opend zul je merken dat er al enige commentaar in staat.
Dit zal je al een beetje op weg helpen.
Maar, voor een korte recap, we installeren (in deze volgorde):

    1. Bovenaan staan alle variabelen die we gebruiken, hierdoor kan de gebruiker makkelijk de configuratie van zijn account personaliseren
    2. Tomcat + grafische interface
    3. MariaDB server & Java openJDK
    4. opstarten en enablen van tomcat en mariaDB
    5. Hierna voeren we het MySQL_Secure_Installatin-script uit, maar alleen als het wachtwoord van de root-user voor MariaDB nog niet is ingesteld  
    6. Als laatste stellen we de firewall in zodat SQL, SSH en de poort 8080/tcp kan uitgevoerd worden

In het tweede script staat de initialisatie van MariaDB en connectie die zal worden gemaakt met de applicatie via wp-config.php
Een korte beschrijving van alle stappen:  

    1. Ook hier staan alle variabelen bovenaan gedefinieert zodat deze makkelijk aanpasbaar zijn  
    2. Hierna maken we één tabel aan voor het beheren als voorbeeld  
    3. Als laatste kopieëren we de WAR file dat lokaal staat naar de server  
   
## Part 3: Hoe scripts laten lopen 

Open een instantie van Git Bash in de directory waar ook het vagrantfile-bestand staat. Voer dan het volgende commando uit:

    vagrant up
    
Dit zal de installatie starten van het webapplicatieplatform.
Je zal hier even moeten wachten.

Nadat de installatie voltooid is kun je in dezelfde console met het volgende commando een remote verbinding maken met het aangemaakt platform
    
    vagrant ssh



 Auteur(s) testplan: Bert Provoost
