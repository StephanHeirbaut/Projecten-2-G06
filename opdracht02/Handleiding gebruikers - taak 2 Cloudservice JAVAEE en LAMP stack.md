# Handleiding gebruikers: Cloud Services JAVAEE en LAMP

## Part 1: DigitalOcean 
Voor de cloudservices van de JAVAEE en LAMP stack hebben we gekozen voor DigitalOcean.
Als eerste heb je natuurlijk een account nodig van DigitalOcean. 

![aanmelden](https://cloud.githubusercontent.com/assets/17174539/25784124/92a9229a-3368-11e7-9555-c88f91f7e22f.png)

Als dit je gedaan dan log je en kom je bij de DigitalOcean Droplets uit.
Hier zullen we dan aan de slag gaan om een nieuwe droplet te creeëren.

![createdroplet](https://cloud.githubusercontent.com/assets/17174539/25784127/92abbe24-3368-11e7-866b-bf37ad66c535.png)

## Part 2: Droplet creeëren
Als eerste zul je dit te zien krijgen. Hier kiezen we voor CentOS 7.3.1611 x64.
De grootte en de kracht van de Droplet kies je zelf, wij hebben gekozen voor de goedkoopste optie.

![opties1](https://cloud.githubusercontent.com/assets/17174539/25784128/930c5c0c-3368-11e7-8da0-e6392e764f48.png)

Hierna kun je nog een block storage toevoegen. Dit hebben wij overgeslaan, maar kan van toepassing zijn voor jouw applicatie.
Daarna zul je een datacenter locatie moeten kiezen. Hier kozen wij voor Amsterdam, maar dat is natuurlijk relatief tot jouw eigen locatie.

![opties2](https://cloud.githubusercontent.com/assets/17174539/25784133/9311f07c-3368-11e7-905d-57cf13efed1e.png)

Hierna zul moet je een SSH key toevoegen aan de droplet zodat je vanop afstand je systeem kunt overnemen via de console.
Maar, eerst zullen we er één moeten aanmaken. Open daarom een Bash console en voer de onderstaande commando's in.

![generatekey](https://cloud.githubusercontent.com/assets/17174539/25784125/92a9c20e-3368-11e7-8c45-1de2bcb6cf89.png)

![inhoudkey](https://cloud.githubusercontent.com/assets/17174539/25784126/92ab6da2-3368-11e7-96be-897a11b52f52.png)

Als dit allemaal gebeurt is kopieer je uitkomst van het laatste commando en plak je deze erna in SSH key content en geef je je SSH key een naam.

![sshkey](https://cloud.githubusercontent.com/assets/17174539/25784130/930f5948-3368-11e7-8626-29a9b69b6e41.png) 

![sshkeyingevuld](https://cloud.githubusercontent.com/assets/17174539/25784131/930f53d0-3368-11e7-8295-fe35eebf58c8.png)

Daarna moet je nog kiezen hoeveel instanties je van de droplet wilt aanamaken en gewoon op 'Create' klikken en even geduld hebben.
Nadat de droplet(s) zijn aangemaakt, zul je terug op de DigitalOcean Droplet-pagina zijn waar je je aangemaakte droplets zult zien.

![create](https://cloud.githubusercontent.com/assets/17174539/25784122/92a71360-3368-11e7-9a94-a70e279d3fbc.png)

Nadat je droplet is aangemaakt moeten we hem alleen nog provisionen.
Hiervoor linkerklik je op het IP adres van de droplet waarna deze gekopieerd wordt.
Daarna moet je alleen nog een bash-console starten in de JAVAEEstack of LAMPstack directory en voer je daar deze commando's in uit.
Het IP adres voor het 'ssh root@ipadress'-commando kun je plakken.

![dropletaangemaakt](https://cloud.githubusercontent.com/assets/17174539/25784123/92a87426-3368-11e7-92ac-0b1b3b4e5197.png)

![provisioning1](https://cloud.githubusercontent.com/assets/17174539/25784132/9310b5ae-3368-11e7-9225-62c857880c45.png)

![provisioning2](https://cloud.githubusercontent.com/assets/17174539/25784129/930ebd8a-3368-11e7-9929-f8e5d57f5f59.png)


Auteur(s) Stephan Heirbaut
