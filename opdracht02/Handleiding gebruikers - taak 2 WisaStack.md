# Handleiding gebruikers: WISA Stack 

Voor de WISA stack hebben wij gekozen voor een Windows 2012 R2 server core omdat we het OS zo licht mogelijk wouden houden. En deze omgeving is   
In deze stack zitten er nog ISS webserver, SQL server en Asp.net.  

## Part 1: Installatie nodige software  

  **Vagrant installeren**
    
 Vagrant gebruiken we om de scripts te laten uit te voeren en een virtuele machine te generen.
 Je kan vagrant downloaden met de volgende link: https://www.vagrantup.com/downloads.html 
 
 **Virtual box installeren** 
  Virtual box hebben we nodig voor een virutele machine te kunnen laten generen door vagrant. 
  Deze kan je downloaden met de volgende link: https://www.virtualbox.org/wiki/Downloads. 
    
  **Git installeren** 
  Om de files te gebruiken die op git hub staan. Moet je natuurlijk ook eerst git installeren op je locale machine. 
  Deze kan je downloaden met de volgende link: https://git-scm.com/downloads
 
 
## Part 2: Git lokaal zetten 
  
   Eerst gaan we de files die nodig zijn lokaal zetten. Je opent in de map waar je wilt clone een git bash 
     
![Gitbash](https://cloud.githubusercontent.com/assets/17159222/24856757/1ad2eca2-1de6-11e7-8e23-3e62dd137a8c.png)

   Dan krijg je volgend scherm: 
   
 ![Gitbash_open](https://cloud.githubusercontent.com/assets/17159222/24856928/b13fb102-1de6-11e7-8d1e-473d51f13929.png)
    
Hierin voer je dan het volgende commando:

    git clone https://github.com/HoGentTIN/p2ops-g06-1.git
    
Als alles goed gaat zul je nu een lokale instantie hebben van deze bestanden. Ga nu in deze nieuw gecreëerde directory en open de WISA stack directory.

## Part 3: Virtuele machine opzetten 

Nu ga je naar de locatie waar de vagrant file staat. 
Daar open je een bash script. En daar voer je dan het  volgende commando in:
    
    vagrant init kensykora/windows_2012_r2_standard_core
    
    
Dit zal een base box van Windows 2012 R2 core intitialiseren en het bestand vagrantfile die we gaan gebruiken voor de stack.  
Telkens we de server willen opstarten ga je in de folder waar de vagrantfile staat het volgende commando uitvoeren:  

    vagrant up

Nu worden de scripts uitgevoerd. Dit kan even duren. 

## Part 4: Virtuele machine 

Als de scripts zijn uitgevoerd, dan kan u naar virtual box gaan. 
Daar zal dan een machine staan. Als u op run klikt, dan start uw machine op.

![vbbox](https://cloud.githubusercontent.com/assets/17159222/24909183/2ddeeb06-1ec3-11e7-9852-5fcdce78c6e5.png)

Het standaard wachtwoord is: vagrant. Nu kan u werken in u virtual machine. 

## Part 5: Databank initialiseren 

[Quinten]


## Part 6: Webapplicatie initialiseren 
[Quinten]


Auteur(s): Jodie De Pestel
