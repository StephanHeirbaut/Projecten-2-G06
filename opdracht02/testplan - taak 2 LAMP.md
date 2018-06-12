# Testplan Opdracht 02: LAMP stack

Voor de LAMP stack hebben wij gekozen voor een CentOS 7 server omdat we daar al meer ervaring mee hadden door opdracht 2.5.  
Verder zit er in deze stack ook nog MariaDB, PHP en Apache.  

Wij hebben gewerkt met Git Bash dus alle commando's die we hier zullen beschrijven zijn uitgevoerd in Bash.  

We hebben 2 scriptjes gemaakt om de installatie uit te voeren en om er een testapplicatie op te laten runnen, namelijk:  

    1. scriptLAMPstack.sh  
    2. testappscript.sh  

Om te beginnen ga je naar de folder waar je de bestanden van de LAMP stack wilt hebben en voer daar in je bash het volgende commando uit:
    
    vagrant init bertvv/centos72  
    
Dit zal een base box van CentOS 7.2 intitialiseren en het bestand vagrantfile die we gaan gebruiken voor de stack.  
Wij hebben die vagrantfile aangepast zodat onze server een vast IP adres krijgt en dat er 2 scripts worden uigevoerd, namelijk:  
  
    1. scriptLAMPstack.sh
    2. testappscript.sh
    
Dit gebeurt door de volgende lijnen te injecteren in het vagrantfile-bestand, nadat je alle andere lijnen hebt verwijdert.

    Vagrant.configure("2") do |config|
      config.vm.box = "bertvv/centos72"

      config.vm.network "private_network", ip: "192.168.56.10"

      config.vm.provision :shell, path: "scriptLAMPstack.sh"  
      config.vm.provision :shell, path: "testappscript.sh"  
    end

De inhoud van de provisioning scripts, 'scriptLAMPstack' en 'testappscript', kun je bekijken via Vim.  
We hebben hierin immers commentaar voorzien voor de gebruiker.

Telkens we de server daarna willen opstarten ga je in de folder waar de vagrantfile staat het volgende commando uitvoeren:  

    vagrant up  
    
Door dit commando zal hetgeen dat in de vagrantfile staat uitgevoerd worden.  
De base box van CentOS zal worden aangeroepen, het IP adress zal worden ingestelde en de 2 scripts worden uitgevoerd.  

Het eerste script (scriptLAMPstack.sh) bevat alle commando's om MariaDB, Apache en PHP te installeren.  
Meer info over de commando's vind je in het script zelf in commentaar boven elk commando.  

Het tweede script (testappscript.sh) bevat de commando's om de databank die gemaakt is in het vorige script in te vullen met rijen en kolommen die we nodig hebben voor onze applicatie. 
Dit zal er eerst voor zorgen dat er een tabel voor users zal aangemaakt worden. Waarna we ervoor zorgen dat het script zal runnen vanaf de root/homedirectory. Hierzal hij via wget de recentste versie van wordpress ophalen en deze installeren en synchroniseren met /var/www/html/.
Tenslotte overschrijven we het wp-config.php-bestand met onze eigen versie hiervan. Als de gebruiker een andere installatie wilt uitvoeren, kan hij het meegegeven wp-config.php aanpassen of er zelf één genereren naar smaak en deze meegeven met het script.

Om hierna verbinding te maken met de opgestelde server voor je het volgende commando uit, nog steeds in directory waar het vagrantfile staat.

    vagrant ssh




    
Auteur(s) testplan: Stephan Heirbaut.
