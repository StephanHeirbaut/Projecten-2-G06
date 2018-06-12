# InstallatieProcedure taak 2: WisaStack  

Part 1: Installatie nodige software  

    a. Vagrant installeren
    
    Vagrant gebruiken we om de scripts te laten uit te voeren en een virtuele machine te generen.
    Je kan vagrant downloaden met de volgende link: https://www.vagrantup.com/downloads.html 
 
    b.Virtual box installeren 
    Virtual box hebben we nodig voor een virutele machine te kunnen laten generen door vagrant. 
    Deze kan je downloaden met de volgende link: https://www.virtualbox.org/wiki/Downloads. 
 
Part 2: Script uitleg 

 In de vagrantfile staan de instellingen voor virtualbox in te stellen. 
 Hier staat dus de provider ingesteld. Dit is bij ons virtualbox. 
 We hebben ook de base box die we gebruiken hier ingezet. 
 Daaronder hebben we het ipadres van de vm ingesteld. 

Onderaan deze file staan 2 verwijzingen naar 2 scripts die we geschreven hebben. 

Het eerste script dat we geschreven hebben installeert IIS webserver en Chocolatery. 
Met Chocolatery installeren we verder de mySQLServer en ASP.net. 

Het 2e script dat we geschreven hebben installeert MySQLserver en de ASP.net. Nadat choco geinstalleerd was moest het cmd heropgestart worden. 
Daarom hebben we er een 2e script van gemaakt. Dat het cmd dan heropgestart word. 


Part 3: Hoe scripts laten lopen 
 
Eerst open je een bash script in de map waar de vagrant file staat. 

```ShellSession
$ vagrant up
```

Na de vagrant up gaan de scripts automatisch lopen. Dit kan even duren. 
 
 Bronnen: 
https://gallery.technet.microsoft.com/scriptcenter/Convert-WindowsImageps1-0fe23a8f
https://www.sitepoint.com/getting-started-vagrant-windows/
https://atlas.hashicorp.com/boxes/search
https://l.facebook.com/l.php?u=https%3A%2F%2Fwww.howtoforge.com%2Ftutorial%2Fvagrant-ubuntu-linux-apache-mysql-php-lamp%2F&h=ATNRV54V1F5iSScEs9HnJ-5pIPYWxYrCum7lQZ5qVb10qI43wYlDaOV-xcDGkM6jIAo5VfHhkYcqbzSM017azRkqpc3xRGoklud-dupoR5Aiy6XM3ywN515HpGkgfoFu59m8AMY
https://dscottraynsford.wordpress.com/2014/12/03/installing-windows-server-2012-r2-core-additional-tools-and-scripts/ 
http://stackoverflow.com/questions/28582116/how-to-install-iis-8-through-code

 Auteur(s) testplan: Jodie De Pestel
