# Opdracht 2: Automatiseren opzetten webapplicatieplatform

## Opdrachtomschrijving

Verschillende klanten vragen ons om hun webapplicatie te hosten. Tot nu toe hebben we altijd manueel een server opgezet waarbij de nodige software geïnstalleerd en geconfigureerd werd. Door de groeiende vraag is dit niet houdbaar. De bedoeling is een soort "serversjabloon" uit te werken zodat we veel sneller een nieuwe server kunnen opzetten die meteen geconfigureerd is om een applicatie op te draaien. Om het voor een webapplicatie-ontwikkelaar eenvoudiger te maken om op haar/zijn eigen laptop een **testomgeving** op te zetten, is de eerste stap het creëren van VirtualBox VMs.

We voorzien in eerste instantie de volgende platformen:

- **LAMP stack**: CentOS 7 of Fedora Server + Apache + MariaDB + PHP
- **WISA stack**: Windows 2012 R2 + IIS + MySQL of SQLServer + ASP.NET
- **Java EE stack**: CentOS 7 of Fedora Server + MariaDB + Java (OpenJDK) + Tomcat 8

De bedoeling is om servers met *exact dezelfde* configuratie in een **productie-omgeving** te kunnen opzetten. We zijn er echter nog niet uit of we zelf de nodige infrastructuur willen opzetten en onderhouden (**private cloud**), of dit uitbesteden via een Infrastructure as a Service provider (**public cloud**). Public cloud providers die we overwegen zijn [Digital Ocean](https://www.digitalocean.com/) (50$ credits verkrijgbaar via [Github Student Pack](https://education.github.com/pack)), of [Amazon Web Services](https://aws.amazon.com/s/dm/landing-page/start-your-free-trial/) (12 maand gratis trial, maar wel kredietkaart nodig bij activeren).

## Acceptatiecriteria

- Het moet voor een applicatie-ontwikkelaar eenvoudig zijn om een testomgeving op te zetten voor het draaien van een webapplicatie met database-backend.
- Het opzetten van deze servers moet **exact reproduceerbaar** zijn. Om écht op schaal bruikbaar te zijn, moet je het installatieproces automatiseren. Dat kan door gebruik te maken van een automatiseringstool zoals [Vagrant](http://vagrantup.com/), gecombineerd met een installatiescript (Bash, PowerShell) of een "configuration management system" zoals [Ansible](http://ansible.com/)). Voor een voorbeeld, zie <https://github.com/bertvv/lampstack/> (je mag dit hergebruiken en er verder op bouwen).
- Er is de nodige aandacht besteed aan herbruikbaarheid.
    - De scripts zijn bruikbaar op verschillende types systemen: binnen de VirtualBox testomgeving op je desktop, binnen één van de opgegeven public/private cloud platformen.
    - Instellingen die specifiek zijn voor een applicatie (bv. initialisatie database, installatie applicatie op de server) zijn configureerbaar. Vermijd dus "hard-coded" data tussen de code, maar gebruik waar mogelijk variabelen.
- Er is een proof-of-concept opgezet met een public cloud platform (hetzij uit de opgegeven providers/producten hetzij een ander na afspraak met de begeleiders) voor minstens één van de types applicatieservers.

## Deliverables

Demo tijdens de contactmomenten van:

- Testomgeving met VirtualBox voor alle gevraagde platformen:
    - Toon hoe de VMs kunnen geïnitialiseerd worden.
    - Toon hoe een applicatie op de VM kan geïnstalleerd worden.
    - Laat een geschikte, werkende demo-applicatie zien die gebruik maakt van een database.
- Proof-of-concept met een public en een private cloud platform.

Op Github:

- Lastenboek
- Alle achtergrondinformatie die jullie verzameld hebben om met de opdracht aan de slag te kunnen gaan
- Gedetailleerde installatieprocedures en scripts (gericht naar de teamleden)
- Handleiding voor gebruikers, i.e. developer die een testomgeving voor een webapplicatieserver wil opzetten (incl. initialisatie database en applicatie)
- Testplannen en testrapporten
