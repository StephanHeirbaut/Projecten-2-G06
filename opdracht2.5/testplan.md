# Testplan opdracht 2.5: Installatie fysieke server

##Gebruikte resources:
* https://www.linode.com/docs/databases/mariadb/how-to-install-mariadb-on-centos-7
* http://www.computerhope.com/
* https://www.digitalocean.com/community/tutorials/how-to-set-up-a-firewall-using-firewalld-on-centos-7

###Part 1: Installeer de laatste versie van CentOS 7.  
    a. Maak dat eerst alle kabels gecontecteerd zijn (Power, USB, VGA en ethernet).  
    Start daarna de computer op. Als er hier al problemen optreden check dan zeker eens de Power- en VGA-kabel.  
    Let wel op! Van zodra de computer begint te booten moet je op F12 beginnen duwen. Anders mis je de mogelijkheid om te booten vanop een ander media.  
    Als dit gelukt is zul je scherm krijgen met enkele keuzes. Kies voor 'onboard network controller'. En, daarna voor 'CentOS install'.  
    Heb nu even geduld, zodra zal het CentOS welkomscherm verschijnen.  
    
    b. Normaal gesproken zal het al geconfigureerd zijn in het Nederlands(Belgisch). Maar, zo niet kun je de taal kiezen door in de linkertabel te zoeken naar Nederlands/Dutch en daarna op de rechtertabel Nederlands(Belgisch) aan te duiden.  
    Hierna zal het scherm met het 'Installatie Overzicht' verschijnen. Ook hier zullen de meeste default instellingen al goed staan.  
    
        * 'Datum&Tijd' zouden op Europa/Brussel tijdzone moeten staan. Zo niet klik je hier eens op en wijzig je deze door op de map te klikken.
        * 'Language support' zou ook op Nederlands(Belgisch) moeten staan. Maar, anders wijzig je deze ook door er gewoon op te klikken en de juiste taal te kiezen.
        
        * Security zal normaal standaard 'no policy' hebben. Als dit niet het geval is duidt u dit nu aan.
        
        * Bij 'Toetsenbord' zal er normaal Nederlands(alternatief) of Belgian(Azerty). Zo niet zul je deze moeten opzoeken uit de lijst van toetsenborden, of misschien heb je een ander type aangesloten.  
        
        * Voor 'Installatiebron' zou je een netwerkadres hebben moeten staan. 172.22.0.2/tftproot/prefix/centosdvd. Hierin hebt u niet veel keuze
        * Bij 'Softwareselectie' zou er normaal 'minimal install' moeten staan. Als dit er niet staat klikt u erop en wijzigt u dit naar deze instelling.
        
        * Bij 'Installatiebestemming' zal u misschien al het orangje uitroepingsteken hebben gezien. Hier zullen we het één en ander moeten wijzigen. Om te beginnen maakt u dat de schijf is aangevinkt en dat automatisch partitionering is aangeduid. Er zullen al OS-en op de schijf staan, deze kunt u dan verwijderen door op 'verwijder alles' te klikken en deze ruimte terug te vorderen zodra u deze prompt krijgt. Deze prompt krijgt u normaal zodra u op 'automatisch partitioneren configureren' klikt.
        * Bij 'Netwerk&Hostnam' klikt u eens op het logo en controleert u eens door op configure te drukken of de onboard netwerkkaart ingesteld is om netwerkinstellingen via DHCP te ontvangen en geactiveerd wordt bij opstarten (onder de tabbladen 'General', 'Ethernet' en 'IPv4 Settings').
        
    Hiermee is alles klaar om te installeren en kunt op 'begin installatie' klikken.  
    Terwijl de installatie bezig is zult u al enkele dingen van Part 2: Systeemconfiguratie kunnen doen.  
        
###Part 2: Systeemconfiguratie.  
    a. Op het scherm dat u ziet kunt u al het root-wachtwoord en een gebruiker gebruiker aanmaken.  
    Vul als rootwachtwoord: bops0groc$ in.  
    En, maak als gebruiker een account aan door admin en het wachtwoord Ewokibnim9 in te voeren, maar maak deze nog niet aan. Controleer eerst door op 'Geavanceerd' te klikken of deze gebruiker in de groep 'wheel' zit. 
    Hierna is het nog even wachten geblazen.  
    Als de installatie tenslotte gedaan is zal de computer heropstarten en kunnen we aan de slag. Laat deze keer gewoon de computer opstarten, druk op niets!  

###Part 3: Software-installatie.  
    a. Nadat de computer is opgestart kunnen we eindelijk beginnen met het installeren van de software. Maar, als eerste moet er eerst nog een bestand op ons systeem worden gezet. In dit bestand zit de publieke SSH-sleutel (`id_rsa_jj.pub`), zodat het mogelijk is om later remote te verbinden met de computer. Dit doe je door simpelweg de sleutel de plaatsen in de home directory van 'admin' en ('/home/admin, herkenbaar aan de '~') en door deze ook te steken in de map '/home/admin/.ssh/authorized_keys'.  
    
    De makkelijkste manier die wij hebben gevonden was om het bestand op een FAT32 (!!) geformatteerde USB-stick te zetten en het daar van af te halen. Hieronder staan alle commando's in volgorde die nodig hebt om het bestand van de stick te halen en deze op de juiste locaties te zetten. Deze commando's zijn uitgevoerd vanaf de home directory van admin.  
    De commando's die hiervan nodigt hebt zijn:  
        1. Eerst maken we een directory aan waarin we het volume (de disk) zullen mounten door 'mkdir usb' in te voeren.
        2. Daarna voer je 'sudo blkid' uit, dit commando toont de gegevens van alle gemounte volumes. Zoek naar het volume dat overeenkomt met je stick (controleer, bijvoorbeeld, op naam). En, noteer het pad waaronder de stick staat (bijvoorbeeld: /dev/sda1)
        3. Voer daarna 'sudo mount /dev/*vul aan met het verdere pad van jouw USB* usb' uit. Dit zal het volume mounten in de directory 'usb'.
        4. Kopieer daarna het bestand van usb naar de home directory door 'cp usb/id_rsa_jj.pub .' uit te voeren.
        5. Hierna kun je controleren of het bestand in je home directory zit door 'ls' uit te voeren. Zo niet, kun je kijken of je volume correct gemount is door 'ls usb'. Misschien is er daar al iets fout gegaan.
        6. Verander vervolgens de rechten van het bestand met 'chmod 700 id_rsa_jj.pub'.
        7. En, controleer dit met 'ls-l'. Er zou 'rwx r-- r--' bij 'id_rsa_jj.pub' moeten staan.
        8. Maak vervolgens een nieuwe directory aan met 'mkdir .ssh'.
        9. En, creëer daarin een bestand met 'touch .ssh/authorized_keys'.
        10. Kopieer vervolgens de gegevens van je home directory naar het bestand met 'cat id_rsa_jj.pub >> .ssh/authorized_keys'.
        11. Als laatste pas je hier ook de rechten aan met 'chmod 700 .ssh/authorized_keys'
    Als alles goed verloopt zal het bestand nu op de juiste locaties staan. Mogelijk problemen zijn er bij het lokaliseren van het pad naar de USBstick of het volumetype. Kijk dus zéér goed naar de output van het commando 'blkid'. Het andere probleem is als je USB geformatteerd is in NTFS. Als oplossing kun je de stick (tijdelijk) formateren naar FAT32.
    
    Nu dit achter de rug is kunnen we beginnen met de installatie van MariaDB. Ter assistentie staat er bovenaan ook nog een handige link van een guide voor een installatie van MariaDB. Maar, als je commando's hieronder volgt moet het geen probleem zijn.
        1. sudo yum install mariadb-server.
        2. Even wachten.
        3. Er zal een prompt volgen, druk y+enter.
        4. Er zal nog een prompt volgen, druk y+enter.
        5. Nog even wachten tot 'Compleet!' verschijnt.
        6. Hierna voer je nog 'sudo systemctl enable mariadb' uit. Dit zal de service opstarten tezamen met het besturingssysteem.
        7. En, 'sudo systemctl start mariadb'. Hiermee wordt de service onmiddelijk opgestart.
        
###Part 4: Beveiliging.  
    Hierna volgen noge enkele beveiligende maatregelen.
        1. Begin als eerste met het script 'sudo mysql_secure_installation' uit te voeren. Dit zal de veiligheid van MariaDB verstevigen.
        2. Dit doe je door het root-wachtwoord van MariaDB in te stellen naar 'Wi0rnyarr'.
        3. En, aangeraden, door 'y' te antwoorden op alle prompts die hij daarna vraagd. Het is evenwel geen slecht idee deze eerst eens allemaal te lezen.
        4. Hierna updaten we alles nog eens met 'sudo yum update'.
        5. Hierdoor zul je waarschijnlijk weer even moeten wachten tot 'compleet!'
        
        Als laatste zullen we de firewall starten en configureren. Ook hiervoor heb ik bovenaan een praktisch instructie en uitlegpagina gevonden voor eventuele help, als deze nodig zou zijn.
        1.  door als eerste 'sudo systemctl start firewalld.service' uit te voeren.
        2. Vervolgens 'sudo firewall-cmd --state'.
        3. Hierna moet je nog het commando 'sudo firewall-cmd --permanent --add-service=mysql'.
        3. En, 'sudo firewall-cmd --permanent --add-service=ssh'.
        
        Vervolgens kun je best nog even controleren in de root of SELinux active is door de volgende commando's uit te voeren
        1. Je logt in als root met 'sudo su'
        2. Je voert dan 'selinux' in en dit zal dan melden of SELinux nog actief is of niet meer.
        3. Als dit niet het geval is, zul je bestand '/etc/sysconfig/selinux' moeten aanpassen met 'nano /etc/sysconfig/selinux' zodat 'SELINUX=permissive' en 'SELINUXTYPE=targeted' er staat.
        

Auteur(s) testplan: Stephan Heirbaut.


