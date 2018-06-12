# Testplan Opdracht 02: Cloud Services 

Voor cloudservices hebben we gekozen voor met Amazon Web Services te werken voor de WISA stack en voor DigitalOcean voor de LAMP en JAVAEE stack.
Als eerste hebben we natuurlijk een account aangemaakt bij Amazon Web Services en DigitalOcean.

Als dit je gedaan dan log je. Dan kan je bij de console uit. 
Hier klik je op Compute -> EC2. 

Eerst maak je een Key pair aan. Dit is om later op de servers te kunnen connecteren. 
Nadat je de naam van de key pair hebt, krijg je ook een .pem bestand. Deze moet je ook bewaren.

Dan ga ja terug naar het EC2 Dashboard. Onder Resources vind je de titel Create Instance. 
Daar duw je op de knop Launch Instance.

Dan moet je eerst kiezen welke AMI (Amazon Machine Image). 
Als je dit gekozen hebt dan kan je de specificatie kiezen van je machine. We hebben Free Tier Eligible gekozen, dit is gratis.

Op het volgende scherm moet je instance configueren. We hebben dit gewoon standaard gelaten. 
Dan krijg je een review van de server. 
Als je dan op Launch klikt krijg je een popup scherm, hier moet je de key pair kiezen. 
Deze keypair heb je in het begin aangemaakt. 
Dan kan je de instance launchen. 

Voor de instance te bereiken hangt het van besturingssysteem af.

Bij Windows is dit het makkelijkste. Je gaat naar je instance en dan klik je met je rechtermuis op de server. Daar klik je op connect. 
Dan krijg je een popup scherm. Hier kan je het remote desktop file downloaden. 
Dan klik je op Get Password, hierna krijg je de vraag om de Key pair path in te voeren.
Zo decrypteer je het wachtwoord. Dan kom je terug bij het eerst pop-up scherm. 
Nu kan je de remote dekstop file openen. 
Dan vul je het bijhorende password in en dan ben je ingelogd op de remote desktop sessie.  
Je server logt automatisch in. De eerste keer kan dit wat lang duren, omdat alles nog opgezet moet worden. 
Hier kan je dan gewoon via het clipboard de scripts laten lopen in powershell. 
Tot zover voor de WISA stack.


Voor de LAMP en JAVAEE stack ga je naar de website van DigitalOcean, klik je op log in en met je je aan met je login gegevens.
Hierna zul je een scherm te zien met je Droplets. Deze zal normaal nog leeg zijn. Hiervoor klik je bovenaan op 'Create Droplet' (grote groene knop).
Vervolgens klik je op CentOS, versie 7.3.1611 x64, kies je hoe groot en stevig je systeem wilt zijn, in welke regio je de Droplet wilt aanmaken en eventueel enkele additionale opties.
Als laatste moeten we een SSH-key toevoegen, maar die zullen we eerst nog moeten creeëren. Hiervoor open je best een instantie van een Bash-console en voer je de volgende commando's in:

      ssh-keygen -t rsa

Hierna kun je best gewoon tweemaal op enter drukken, maar eventueel kun je de naam van het bestand opslaan onder een andere naam of een wachtwoord geven.
Vervolgens kopieer je de inhoud ervan met:

      cat ~/.ssh/id_rsa.pub
      
of, als je het bestand een andere naam hebt. Tip: ls -la ~/.ssh

      cat ~/.ssh/naamBestand.pub
      
Kopieer de output van dit commando en ga terug naar de webpagina van DigitalOcean. Klik nu op 'New SSH Key', plak de output van het commando nu in 'SSH key content' en geef een naam aan je SSH key. Sluit het nu af door te klikken op 'Add SSH Key'.

Hierna kun je kiezen hoeveel instanties je van deze Droplet wilt maken. Maar, al wat er nog te doen valt is op 'Create' klikken en even geduldig wachten.

Nadat je Droplet is aangemaakt zal deze nu verschijnen tussen je Droplets. Het enigste wat je nu nog moet doen is eens likker klikken op het IP Address dat vermeld staat bij je Droplet.

Waarna je de provsioning kan doen door een Bash console te openen in de LAMPstack of JAVAEEstack directory met het volgende commando's:

LAMP:

      ssh root@IPAddressDroplet < scriptLAMPstack.sh
      ssh root@IPAddressDroplet < testappscript.sh
      

JAVAEE:

      ssh root@IPAddressDroplet < scriptJAVAEEstack.sh
      ssh root@IPAddressDroplet < testappscript.sh


Auteur(s) Jodie De Pestel en Stephan Heirbaut
