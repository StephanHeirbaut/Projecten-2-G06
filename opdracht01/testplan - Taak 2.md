# Testplan taak 2: Building a Simple Network 

Part 1: Set Up the Network Topology (Ethernet only)
  Step 1: Power on the devices 
  
  Eerst moet je alle netwerkapparatuur aanzetten. (In packet tracer moet dit niet) 
  De switch die we  gebruiken is een 2960 en generic desktop. 
  In packet tracer geef je apparatuur de juiste naam. Zie foto van schema hieronder de oefening. 
  
  
![Schema ](https://cloud.githubusercontent.com/assets/17159222/23117282/3cb83600-f74f-11e6-8336-d32109ff9479.png)


  Step 2: Connect the two switches 
  
    Hier gaan we de switchen met elkaar verbinden 
    Dit doen we met een Copper Straight-Through kabel (packet tracer) of ethernetkabel (fysieke uitwerking) 
    We sluiten ze allebei aan op poort FastEthernet0/1.
    De connectie moet een groen bolletje tonen. Dit betekent dat alles correct is. 


  Step 3 : Connect the PCs to their respective switches
  
    Hierin gaan we de switchen aan de pc's hangen. 
    
    a. Connect one end of the second Ethernet cable to the NIC port on PC-A
    
    Je steekt de ethernetkabel of Copper Straight-Through kabel in poort fastEthernet F0/6 van de switch.
    Bij de pc is dit in poort fastEthernet F0
    
    b. Connect one end of the last Ethernet cable to the NIC port on PC-B
    Je steekt de ethernetkabel of Copper Straight-Through kabel in poort F0/18 van de switch.
    Bij de pc is dit in poort fastEthernet F0.
    
  Step 4: Visually inspect network connections 
  
     De connectie moet een groen bolletje tonen. Dit betekent dat alles correct is. 
     Dit kan een paar seconden duren of je klikt op Fast forward time.

-------------------------------------------------------------------------------------------
Part 2: Configure PC Hosts 
  Step 1: Configure static IP address information on the PCsStep 1: Configure static IP address information on the PCs

    a. Click the Windows Start icon and then select Control Panel 
    
![windowsStart](https://cloud.githubusercontent.com/assets/17159222/23122919/93737736-f766-11e6-832d-c1d64384289b.png)


    b. In the Network and Internet section, click the View network status and tasks link 
    
![networkandInternetSection](https://cloud.githubusercontent.com/assets/17159222/23122986/dd102100-f766-11e6-9edf-fa24f724f541.png)
    
    c. In the left pane of the Network and Sharing Center window
    
![networkandsharingcenterwindow](https://cloud.githubusercontent.com/assets/17159222/23123026/011f7bd6-f767-11e6-87dc-d2ee41d3138b.png)
    
    d. The Network Connections displays the available interface on the PC
    
![LANinstellen](https://cloud.githubusercontent.com/assets/17159222/23123066/26525c2a-f767-11e6-93ce-938ca388c299.png)
    
    e. Select the Internet Protocol Version 4 (TCP/IPv4)
    
 ![ipv4](https://cloud.githubusercontent.com/assets/17159222/23123107/52835d3a-f767-11e6-899b-6bfd53dbf720.png)
    
    f. Click the Use the following IP address radio button to manually enter IP address, subnet , default gateway
    
    
![ipadresseninstellen](https://cloud.githubusercontent.com/assets/17159222/23123141/85fcbd1e-f767-11e6-88f9-506d65f139c8.png)
    
    Dan word subnet Mask automatisch ingevuld. En voor de rest laten we alles gewoon staan zoals het stond.
    Voor IP adress voor PC b gebruiken we: 192.168.1.11
    
    
    g. After all the IP information has been entered, click OK. OK 
    
    h. Repeat the previous steps tot enter the IP address information for PC-B 
    
    Packet tracer 
    Al deze stappen zijn niet nodig in pakket tracer. Dit is voor als met een fysiek device werkt. 
    Voor in pakket tracer de juiste ip adressen toe te kennen aan de pc's. Klik je op de pc. 
    Dan ga je naar de tab Desktop. Klik dan op het icoon van IP Configuration. 
    Dan klik je static aan, want we gebruiken een statisch adres. 
    Je vult bij Ip adress voor PC a: 192.168.1.10 in. 
    Dan word subnet Mask automatisch ingevuld. En voor de rest laten we alles gewoon staan zoals het stond.
    
    Voor IP adress voor PC b gebruiken we: 192.168.1.11


  Step 2: Verify PC settings and  connectivity
    
    Al deze stappen zijn niet nodig in pakket tracer. Dit is voor als met een fysiek device werkt.
    Voor de connectie te testen in pakket tracer klik je op pc. Dan ga je naar de tab desktop. 
    Hier klik je op het icoon voor Command Prompt. 
    Dan voer je het commando : ipconfig /all uit. 
    Dit toont de gegevens van het netwerk. Dit is niet helemaal hetzelfde als in windows. 
    
    Dan gaan we kijken of we de andere computer kunnen bereiken. 
    Van PC a naar PC b gebruik je het volgende commando: ping 192.168.1.11
    En van Pc b naar PC a gebruik je het volgende commando : ping 192.168.1.10 
    
    Dit moet normaal lukken. 
    Anders moet je troubleshooten en kijken of je Ipadressen juist zijn ingesteld.
    Dat je niet perongeluk op het verkeerde subnet zit. 



---------------------------------------------------------------------------------------------------------
Part 3: Configure and Verify Basic Switch Settings 
  
  Step 1: Console into the switch
  
  
 
    Tera term kan niet worden gebruikt in pakket tracer. Je kan je switch instellen via je terminal van je pc/ 
    (zie hieronder) 
    Voor de switch instellen hebben we een console kabel nodig van switch naar pc.
    Bij de Pc steken we die kabel in poort RS 232 en bij de switch in de console poort. 

  Step 2: Enter privileged EXEC mode 
  
    Je klikt op de pc. Ga naar de tab Desktop en klik je daarna op het icoon van terminal. 
    Je laat de instellingen standaard staan en klikt gewoon op ok.
    Dan kom je terecht in de terminal van de switch. 
    Je klikt op return. 
    Nu gaan we naar privileged exec mode door enable of en in te tikken 
    Dan verander het command prompt van user naar privileged 

  Step 3: Enter Configuration mode
    
    Je voert het commando config terminal (of term)  in om de configuratie mode te geraken. 


  Step 4: Give the switch a name 
  
    Je voert het commando hostname S1 om de switch te hernoemen 

  Step 5: Prevent unwanted DNS lookups 
  
    Je voer het commando no ip domain-lookup in. Dit voor dat de switch geen verkeerde ipadressen geeft

  Step 6: Enter local passwords 
  
    Hier gaan we basic security instellen 
    Eerst gaan we het commando enable secret class gebruiken. 
    Hierna tikken we het commando  line con (configuration) 0.
    Als we in deze configuration zitten voeren we het commando: password cisco in. 
    Dan voeren we het commando login in. 
    Dan gaan we via het commando exit uit deze configuration 


  Step 7: Enter a login MOTD banner 
  
    Je voert het volgende commando in: banner motd #Autorized Access Only# 
    Tussen de # staat je boodschap. 
    Dan gaan we via het commando exit uit deze configuration.

  Step 8: Save the configuration 
  
    Hier gaan we configuratie dat we net hebben ingegeven opslaan. 
    Dit doen we met het volgend commando: copy running-config startup-config

  Step 9: Display the current configuration 
  
    Hier gaan we de configuratie die nu draait op de switch bekijken. 
    Of het wachtwoord wel encrypted is. Je kan ook hier je banner zien. 
    Dit doe je met het commando:show running-config 

  Step 10: Display the IOS version and other useful switch information 
    
    Nu gaan we kijken naar de OS versie. 
    Dit doe je met het commando show version 

  Step 11: Display the status of the connected interfaces on the switch 
    
    Met het commando show ip interface brief kan je de interfaces van de switchen bekijken. 


  Step 12: Repeat Steps 1 to 12 to configure switch S1
    
    Voor switch 2 doe je het zelfde als voor switch1 (zie hierboven). 

  Step 13: Record the interface status for the following interfaces
    
    Deze tabel kan je invullen door het commando show ip interface brief te doen bij elke switch. 

------------------------------------------------------------------------------
Appendix A: Initializing and Reloading a switch 

  Step 1: Connect to the switch 
  
    Voor de switch instellen hebben we een console kabel nodig van switch naar pc.
    Bij de Pc steken we die kabel in poort RS 232 en bij de switch in de console poort.
    
    Voor van user mode naar EXEC mode te gaan voer je het commando: Enable in. 

  Step 2: Determine if there have been any virtual local-area networks (VLANs) created 
    
    Om te kijken of er VLANs aanwezig zijn voer je het volgend commando uit.
    Show flash.
    
    Hier krijg je een lijst van wat er in de flash zit. Hierin kan je dus ook zien of er een vlan.dat file inzit.

  Step 3: Delete the VLAN file 
    
    Om de VLAN file te verwijderen gebruik je het volgend commando: delete vlan.dat
    Dan vragen ze nog eens een verify van de naam, je drukt gewoon op enter en dan vlan is verwijdert. 

  Step 4: Erase the startup configuration file 
    
    Om een startup config file te verwijderen gebruik je het volgend commando
    erase startup-config

  Step 5: Reload the switch 
    
    Om de switch te herladen om bijvoorbeeld de oude config informatie uit het geheugen te verwijderen.
    Gebruik je het volgend commando: reload 

  Step 6: Bypass the initial configuratuin dialog 
    
    Nadat de switch is herlaad krijg je een vraag om in een initiall config dialog te gaan. Je tikt no.
    En hierna zit je terug in de User EXEC mode. 

Auteur(s) testplan: Jodie De Pestel
