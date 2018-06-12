# Testplan Opdracht 02: WISA stack

Voor de WISA stack hebben wij gekozen voor een Windows 2012 R2 server core omdat we het OS zo licht mogelijk wouden houden. En deze omgeving is   
In deze stack zitten er nog ISS webserver, SQL server en Asp.net.  

Wij hebben gewerkt met Git Bash dus alle commando's die we hier zullen beschrijven zijn uitgevoerd in Git Bash.   

We hebben 2 powershell scripten gemaakt om de installatie uit te voeren en om er een testapplicatie op te laten runnen, namelijk:  

    1. ISSChoco.ps1
    2. MySQLAsp.ps1  

Eerst open je een bash script in de map waar je de bestanden wilt hebben. En daar voer je dan het  volgende commando in:
    
    vagrant init kensykora/windows_2012_r2_standard_core
    
    
Dit zal een base box van Windows 2012 R2 core intitialiseren en het bestand vagrantfile die we gaan gebruiken voor de stack.  
Telkens we de server willen opstarten ga je in de folder waar de vagrantfile staat het volgende commando uitvoeren:  

    vagrant up  
    
Het eerste script dat we geschreven hebben installeert IIS webserver en Chocolatery. Met Chocolatery installeren we verder de mySQLServer en ASP.net.

Het 2e script dat we geschreven hebben installeert MySQLserver en de ASP.net. Nadat choco geinstalleerd was moest het cmd heropgestart worden. Daarom hebben we er een 2e script van gemaakt. Dat het cmd dan heropgestart word.



[Afwerken Quinten] 
Bronnen: 
https://gallery.technet.microsoft.com/scriptcenter/Convert-WindowsImageps1-0fe23a8f
https://www.sitepoint.com/getting-started-vagrant-windows/
https://atlas.hashicorp.com/boxes/search
https://l.facebook.com/l.php?u=https%3A%2F%2Fwww.howtoforge.com%2Ftutorial%2Fvagrant-ubuntu-linux-apache-mysql-php-lamp%2F&h=ATNRV54V1F5iSScEs9HnJ-5pIPYWxYrCum7lQZ5qVb10qI43wYlDaOV-xcDGkM6jIAo5VfHhkYcqbzSM017azRkqpc3xRGoklud-dupoR5Aiy6XM3ywN515HpGkgfoFu59m8AMY
https://dscottraynsford.wordpress.com/2014/12/03/installing-windows-server-2012-r2-core-additional-tools-and-scripts/ 
http://stackoverflow.com/questions/28582116/how-to-install-iis-8-through-code

 Auteur(s) testplan: Jodie De Pestel


