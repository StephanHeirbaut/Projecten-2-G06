# Testplan Opdracht 02: JAVA EE stack

Voor de JAVA EE stack hebben wij gekozen voor een CentOS 7 server omdat we daar al meer ervaring mee hadden door opdracht 2.5.  
Verder zit er in deze stack ook nog MariaDB, Java (OpenJDK) en Tomcat.  

Wij hebben gewerkt met Git Bash dus alle commando's die we hier zullen beschrijven zijn uitgevoerd in Bash.  

We hebben 2 scriptjes gemaakt om de installatie uit te voeren en om er een testapplicatie op te laten runnen, namelijk:  

    1. scriptJAVAEEstack.sh  
    2. testappscript.sh  

Om te beginnen ga je naar de folder waar je de bestanden van de JAVA EE stack wilt hebben en voer daar in je bash het volgende commando uit:
    
    vagrant init bertvv/centos72  
    
Dit zal een base box van CentOS 7.2 intitialiseren en het bestand vagrantfile die we gaan gebruiken voor de stack.  
Wij hebben die vagrantfile aangepast zodat onze server een vast IP adres krijgt en dat er 2 scripts worden uigevoerd, namelijk:  
  
    1. scriptJAVAEEstack.sh
    2. testappscript.sh

Dit gebeurt door de volgende lijnen te injecteren in het vagrantfile-bestand, nadat je alle andere lijnen hebt verwijdert.

    Vagrant.configure("2") do |config|
      config.vm.box = "bertvv/centos72"

      config.vm.network "private_network", ip: "192.168.56.11"

      config.vm.provision :shell, path: "scriptJAVAstack.sh"  
      config.vm.provision :shell, path: "testappscript.sh"  
    end
    
De inhoud van de provisioning scripts, 'scriptJAVAEEstack' en 'testappscript', kun je bekijken via Vim.  
We hebben hierin immers commentaar voorzien voor de gebruiker.

Telkens we de server willen opstarten ga je in de folder waar de vagrantfile staat het volgende commando uitvoeren:  

    vagrant up  
    
Door dit commando zal hetgeen dat in de vagrantfile staat uitgevoerd worden.  
De base box van CentOS zal worden aangeroepen, het IP adress zal worden ingestelde en de 2 scripts worden uitgevoerd.  

Het eerste script (scriptJAVAEEstack.sh) bevat alle commando's om MariaDB, Java (OpenJDK) en Tomcat te installeren.  
Meer info over de commando's vind je in het script zelf in commentaar boven elk commando.  

Het tweede script (testappscript.sh) bevat de commando's om de databank die gemaakt is in het vorige script in te vullen met rijen en kolommen die we nodig hebben voor onze applicatie. 
Hier wordt ook de war file die we nodig hebben om onze applicatie uit te voeren gekopieerd en geplakt in de folder /var/lib/tomcat/webapps.  

Die war file hebben wij al aangepast om deze te laten werken met onze server maar normaal is dit de opdracht van de back-end developper om een goede war file mee te geven.  


Om hierna verbinding te maken met de opgestelde server voor je het volgende commando uit, nog steeds in directory waar het vagrantfile staat.

    vagrant ssh

    
Auteur(s) testplan: Bert Provoost.


