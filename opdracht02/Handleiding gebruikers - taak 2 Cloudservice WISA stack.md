# Handleiding gebruikers: Cloud Services WISA

## Part 1: Amazone 
Voor cloudservices hebben we gekozen voor met amazon webservices.
Als eerst heb je natuurlijk een account nodig voor amazon. 

![amazon](https://cloud.githubusercontent.com/assets/17159222/24909378/f0ba599e-1ec3-11e7-83d6-05a7cf908a6f.png)


Als dit je gedaan dan log je. Dan kan je bij de console uit. 
Hier klik je op Compute -> EC2. 

![EC2](https://cloud.githubusercontent.com/assets/17159222/24909418/179504c4-1ec4-11e7-830e-864ebb89ef04.png)

## Part 2: Key pair 
Eerst maak je een Key pair aan. Dit is om later op de servers te kunnen connecteren. 
Nadat je de naam van de key pair hebt, krijg je ook een .pem bestand. Deze moet je ook bewaren.

![keypair_1](https://cloud.githubusercontent.com/assets/17159222/24909453/42d81478-1ec4-11e7-8ba2-42252622fad1.png)



## Part 3: Instances 
Dan ga je terug naar het EC2 Dashboard. Onder Resources vind je de titel Create Instance. 
Daar duw je op de knop Launch Instance.

![instance](https://cloud.githubusercontent.com/assets/17159222/25092611/cb53ed30-238e-11e7-9317-0eb828a25e2e.png)

Dan moet je eerst kiezen welke AMI (Amazon Machine Image). 

![AMI](https://cloud.githubusercontent.com/assets/17159222/25092643/e408c2ce-238e-11e7-848e-fb1c7b594197.png)

Als je dit gekozen hebt dan kan je de specificatie kiezen van je machine. We hebben Free Tier Eligible gekozen, dit is gratis.


![Tier](https://cloud.githubusercontent.com/assets/17159222/25092683/1685341c-238f-11e7-949a-cb1c6deab1e2.png)

Op het volgende scherm moet je instance configueren. We hebben dit gewoon standaard gelaten. 

![config](https://cloud.githubusercontent.com/assets/17159222/25092707/2d65a1b2-238f-11e7-96eb-72aa104221d7.png)

Dan krijg je een review van de server. 

![review](https://cloud.githubusercontent.com/assets/17159222/25092741/48ba7a28-238f-11e7-983e-eea9fc2ba669.png)

Als je dan op Launch klikt krijg je een popup scherm, hier moet je de key pair kiezen. 
Deze keypair heb je in het begin aangemaakt. 
Dan kan je de instance launchen. 

![instance_launch](https://cloud.githubusercontent.com/assets/17159222/25092759/6077eb50-238f-11e7-8449-13a535512c1f.png)


## Part 4: Windows 
Je gaat naar je instance en dan klik je met je rechtermuis op de server. 
Daar klik je op connect. Dit kan je enkel doen als de server al gestart is. Is dit niet het geval, dan klik je op rechtermuis -> naar status en dan start. Dan zal de server opstarten. Dit kan even duren. 

![instance_connect](https://cloud.githubusercontent.com/assets/17159222/25092896/0b430fa6-2390-11e7-97f6-8fb37e511248.png)


Dan krijg je een popup scherm. Hier kan je het remote desktop file downloaden. 

![remotedesktop](https://cloud.githubusercontent.com/assets/17159222/25092939/4e7470f8-2390-11e7-8354-28a80def4ef1.png)

Dan klik je op Get Password, hierna krijg je de vraag om de Key pair path in te voeren.

![getPassword](https://cloud.githubusercontent.com/assets/17159222/25092950/618a8416-2390-11e7-9e79-255332d81bc2.png)

Zo decrypteer je het wachtwoord. Dan kom je terug bij het eerst pop-up scherm. 
Nu kan je de remote dekstop file openen. 
Dan vul je het bijhorende password in en dan ben je ingelogd op de remote desktop sessie.  
Je server logt automatisch in. De eerste keer kan dit wat lang duren, omdat alles nog opgezet moet worden. 
Hier kan je dan gewoon via het clipboard de scripts laten lopen in powershell. 




Auteur(s) Jodie De Pestel 
