# Opdracht 2,5: Installatie fysieke server

Deze opdracht geldt enkel voor studenten campus Schoonmeersen en moet op maandag 20 februari afgewerkt worden.

## Opdrachtomschrijving

In het netwerklokaal staan nog een aantal afgeschreven machines, type Dell PowerEdge 760. Een aantal van deze pc's zullen worden geschonken aan een relatie voor wetenschappelijk onderzoek.

Jullie opdracht is om op de pc's een basisbesturingssysteem (CentOS 7) te installeren en te configureren zodat ze meteen kunnen ingezet worden.

## Achtergrondinformatie

- RedHat 7 Installation Guide: <https://access.redhat.com/documentation/en-US/Red_Hat_Enterprise_Linux/7/html/Installation_Guide/>
- Ravi Saive (2015). SSH Passwordless Login Using SSH Keygen in 5 Easy Steps <http://www.tecmint.com/ssh-passwordless-login-using-ssh-keygen-in-5-easy-steps/>
    - merk op dat stap 1 al gebeurd is, het sleutelpaar is al aangemaakt.

In het netwerklokaal is het mogelijk om een installatie van CentOS over het netwerk op te starten. Sluit daarom de pc aan op het bekabelde netwerk van het lokaal (let op: slechts één van de twee netwerkkabels per werkplek is aangesloten op een switch, de andere gaan naar het begin van de tafel), en druk F12 om het boot-apparaat te kiezen. Kies voor "network boot". Je zou een keuzemenu moeten krijgen waar de installatie van CentOS 7 er één van is.

## Acceptatiecriteria

- Installeer de laatste versie van CentOS 7
    - Tijdzone Brussel
    - Toetsenbord Belgian Azerty
    - Automatische partitionering, CentOS mag de gehele harde schijf overnemen.
    - Minimale package-selectie
- Systeemconfiguratie:
    - De eerste netwerkkaart (onboard) is ingesteld om netwerkinstellingen via DHCP te ontvangen, en wordt geactiveerd bij opstarten. De tweede netwerkkaart (PCI) wordt niet geactiveerd bij opstarten.
    - Root-wachtwoord: `bops0groc$`
    - Gebruiker `admin` die lid is van de `wheel`-groep met wachtwoord `Ewokibnim9`
    - Installeer de bijgevoegde publieke SSH-sleutel (`id_rsa_jj.pub`) in de home-direcory van `admin`, zodat vanop afstand kan ingelogd worden zonder wachtwoord. Hiervoor moet de inhoud van het bestand toegevoegd worden aan het bestand `/home/admin/.ssh/known_hosts` (aan te maken als het nog niet bestaat). Let er op dat de bestandspermissies van `.ssh/` en `known_hosts` zo restrictief mogelijk moeten zijn: alle permissies voor de eigenaar (maar geen execute-permissies voor het bestand), geen enkele permissie voor andere gebruikers.
- Software-installatie:
    - Installeer MariaDB, zorg ervoor dat de `mariadb` service opstart bij booten.
    - Database-rootwachtwoord: `WiOrnyarr`
    - Doorloop `mysql-secure-installation` en pas de voorgestelde beveiligingsmaatregelen toe.
- Beveiliging:
    - Installeer de laatste updates
    - Zorg dat de firewall geactiveerd is en SSH en database-verkeer (MySQL/MariaDB) doorlaat
    - Zorg dat SELinux geactiveerd blijft (is normaal een standaardinstelling)

## Deliverables

- Afgewerkte pc volgens de specificaties hierboven opgesomd.
    - Voor de verificatie: zorg dat de machine op het klasnetwerk aangesloten is, geef het IP-adres door aan Bert Van Vreckem
- Vat de belangrijkste instellingen samen en schrijf op/druk af op een blad papier dat je op de zijkant van de pc plakt.

Op Github:

- Lastenboek
- Testplan en testrapport
- Gedetailleerde installatieprocedures en scripts
