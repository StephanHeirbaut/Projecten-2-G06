# Testplan taak 4: Lab - Basic static route configuration  
 
 Auteur: Quinten De Bruyne  
    
    
### Task 1: Cable, Erase, and Reload the Routers.  
Step 1: Cable a network that is similar to the one in the topology diagram.  
* Selecteer drie generische computers, drie generische routers en drie generische switchen.  
* Noem de drie pc's PC1, PC2 en PC3.  
* Noem de drie routers R1, R2 en R3.  
* Noem de drie switches S1, S2 en S3.
* Verbind de FastEthernet0 van PC1 met de FastEthernet0/1 van S1 met een copper-Straight trough cable.  
* Herhaal bovenstaande stap met dezelfde kabel en poorten, maar dan van PC2 en S2, én voor PC3 en S3.  
* Verbind de FastEthernet1/1 van S1 met de FastEthernet0/0 van R1 met een copper-straight trough cable.  
* Herhaal bovenstaande stap met dezelfde kabel en poorten, maar dan voor S2 en R2, én S3 en R3.  
* Verbind met een Serial DTE de seriële poort 2/0 van R1 met de seriële poort 2/0 van R2.  
* Verbind met een Serial DTE de seriële poort 3/0 van R2 met de seriële poort 2/0 van R3.  
          
Step 2: Clear the configuration on each router.
- Klik op R1, en gaa naar het tabblad CLI.  
- Typ no en enter indien gevraagd wordt om verder te gaan met een setup.  
- Druk enter.  
- Typ erase startup-config en enter twee maal.  
- Indien gevraagd wordt om iets op te slaan, typ dan no en enter.  
- Doe dit ook voor de twee andere routers.
          
Task 2: Perform Basic Router Configuration  

Step 1: Use global configuration commands & Step 2: Configure the console and virtual line passwords.  
& Step 3: Add the loggin synchronous command to the console and virtual terminal lines.  
& Step 4: Add the exec-timeout command to the console and virtual terminal lines.
- Ga naar de CLI van R1 en druk enter.  
- Typ enable en enter.
- Typ conf ter en enter.  
- Typ hostname R1 en enter.
- Typ no ip domain-lookup en enter.  
- Typ enable secret jouwwachtwoord en enter.  
- Typ line vty 0 4 en enter.  
- Typ password jouwanderwachtwoord en enter.  
- Typ login en enter.  
- Typ logging synchronous in en enter.  
- Typ exec-timeout 0 0 in en enter.  
- Typ line console 0 en enter.  
- Typ password jouwanderwachtwoord en enter.  
- Typ login en enter.  
- Typ logging synchronous in en enter.  
- Typ exec-timeout 0 0 in en enter.  
- Herhaal dit ook voor R2 en R3!  
            
### Task 3: Interpreting Debug Output.  
Step 1: On R1 from privileged EXEC mode, enter the debug ip routing command.  
* Ga naar de CLI van R1 en druk enter.  
* Typ in enable en druk op enter.  
* Geef het wachtwoord in; met name jouwwachtwoord, gevolgd door een enter.  
* Typ debug ip routing in en bevestig met een enter.  
* Normaal krijg je nu de melding "IP routing debugging is on" te zien.  
Step 2: Enter interface configuration mode for R1's LAN interface. 
* Ga naar de CLI van R1 en ga naar privileged EXEC mode (zie eerste drie stappen van Step 1 hierboven).  
* Typ configuret term in en druk op enter.  
* Typ interface fastethernet 0/0 in en druk op enter.  
* Typ ip address 172.16.3.1 255.255.255.0 in en enter.  
Step 3: Enter the command necessary to install the route in the routing table.        
* Ga verder waar je gebleven was en typ in no shutdown, gevolgd daar een toetsaanslag op de enter.  
Step 4: Enter the command to verify that the new route is now in the routing table.
* Typ in show ip route in de privileged EXEC mode in de command line interface van R1.  
* kijk of er C         172.16.3.0 is directly connected, FastEthernet0/0 terug te vinden is.  

Step 5: Enter interface configuration mode for R1's WAN interface connected to R2.  
& Step 6: Enter the clock rate command on R1  
& Step 7: Enter the command necessary to ensure that the interface is fully configured.  
* In de CLI van R1, begeef je naar privileged EXEC mode en typ conf term in gevolgd door enter.  
* Typ interface Serial 2/0 in en enter.  
* Typ ip address 172.16.2.1 255.255.255.0 in en enter.  
* Typ clock rate 64000 in en enter.  
* Typ no shutdown in en enter.  

Step 8:  Stel de interfaces van R2 in.  
& Step 9: Enter the command necessary to ensure that the interface is fully configured. 
* Ga naar de CLI van R2, log je aan in privileged EXEC mode en typ conf term in, gevolgd door enter.  
* Typ interface serial 2/0 in en enter.  
* Typ ip address 172.16.2.2 255.255.255.0 in en enter.  
* Typ no shutdown in en enter.  
  
  
Step 10: Enter the command to verify that the new route is now in the routing table for R1 en R23.  
* In CLI van R1, ga naar privileged EXEC mode en typ in show ip route en enter.  
* Verifieer of je twee verscillende poorten, namelijk Serial 2/0 en FastEthernet 0/0 verbonden zijn  
* Doe hetzelfde voor R2, hier moet echter slechts één poort gebruikt zijn, namelijk de Serial 2/0.  
Step 11: Turn off debugging on both routers using no debug ip routing, oftewel undebug all.  
* Je gaat naar de privileged mode in de CLI in R1 en typt no debug ip routing in, gevolgd door een enter.  

### Task 4: Finish Configuring Router interfaces.
Step 1: Configure Remaining R2 interfaces.     
* Je moet nog de FastEthernet 0/0 van R2 instellen.  
* Hiervoor zal je naar de privileged EXEC mode moeten gaan en conf termin intypen en enteren.  
* Typ interface fastethernet 0/0 in en enter.  
* Typ ip address 172.16.1.1 255.255.255.0 in en enter.  
* Typ no shutdown in en enter.  
* Typ interface serial 3/0 in en enter.  
* Typ ip address 192.168.1.2 255.255.255.0 en enter.  
* Typ no shutdown in en enter.  
  
  
Step 2: Configure R3 interfaces.  
* Ga naar de privileged mode in de CLI van R3, conf term en enter.  
* Typ interface fastethernet 0/0 in en enter.  
* Typ ip address 192.168.2.1 255.255.255.0 in en enter.  
* Typ no shutdown in en enter.  
* Typ interface serial 2/0 in en enter.  
* Typ ip address 192.168.1.1 255.255.255.0 in en enter.  
* Typ no shutdown in en enter.  
* Normaal gezien zijn nu alle verbindingen van de routers geconfigureerd.  

### Task 5: Configure IP Addressing on the Host PCs.  
Step 1, 2, 3: Configure the host PC1, PC2, PC3.    
* Klik op PC1 en ga naar tabblad Desktop.  
* Klik op IP configuration. 
* Check Static aan.  
* Vul bij IP addres 172.16.3.10 in.  
* Vul bij Subnet mask 255.255.255.0 in.  
* Vul bij Default Gateway 172.16.3.1 in.  
* Doe voor PC2 en PC3 hetzelfde, vul als IP address respectievelijk 172.16.1.10 en 192.168.2.10 in.  
* Als Subnet mask mag je bij beiden weer 255.255.255.0 invullen.  
* Als Default Gateway respectievelijk 172.16.1.1 en 192.168.2.1 invullen.  
  
  
### Task 6: Test and Verify the configurations.  
Step 1 :Test connectivity.  
* Pingen kan je van computer naar computer doen. 
* Je kan naar de command line van de computer gaan, ping ipadres en enteren. Uiteraard vervang je ipadres door een ipadres van de te pingen computer.   
* Je kan ook de default gateway pingen.  
* Normaal kan elke van de drie host PC's naar de default gateway pingen. 
* Ook kan je van R2 naar zowel R1 als R3 pingen.  
                     
### Task 7: Gather information  

Step 1: Check status of interfaces.  
* Geef in de CLI van elke router het commando show ip interface brief in.  
* Je krijgt een overzicht van de interfaces en kan zien welke een up state hebben.  
* Normaal moet je bij R2 twee seriele verbindingen (WAN) en één fastethernet (LAN) verbinding up hebben.  
* Normaal moet je bij R1 en R3 een seriele verbinding (WAN) en één fastethernet (LAN) verbinding up hebben.  
  
  
Step 2: View the routing table information for all three routers.  
* Ga in privileged EXEC mode na welke ip routes er bekend zijn. Dit kan met commando show ip route.  
* Je zal zien dat er nog enkele ip addressen uit het topology diagram ontbreken.  
* Dit is te wijten aan het feit dat de routers nog niet geconfigureerd zijn met static of dynamic routing.  
* De routers kennen dus met andere woorden enkel de direct connected networks.
       
### Task 8: Configure a static route using a next-hop address.  
Step 1: The syntax.  
* Ga naar de privileged EXEC mode van R3, typ conf term en enter.  
* Typ ip route 172.16.1.0 255.255.255.0 192.168.1.2  
* Dit laatste ip adres is het IP adres van de next hop, maw de Serial 3/0 van R2.  
      
Step 2: View the routing table to verify the new static route entry.  
* Gebruik het commando show ip route op R3 zoals eerder.  
* Je ziet nu S    172.16.1.0 via 192.168.1.2  
* Dit is dus de static route die je zonet toegevoegd heb.  
* De S geeft aan dat dit static is.  
          
Step 3: Use ping to check connectivity between the host PC3 and the host PC2.  
* Je zal ontdekken dat dit nog niet mogelijk is.  
  
  
Step 4: On the R2 router, configure a static route to reach the 192.168.2.0 network.  
* In privileged EXEC mode van R2, typ conf term en hit enter.  
* Typ ip route 192.168.2.0 255.255.255.0 192.168.1.1 en hit enter.  
* Je hebt net de static route toegevoegd. Dit kan je eventueel in de configure terminal controleren met het commando show ip route.  
   
Step 5: Use ping to check connectivity between the host PC3 and the host PC2.    
* Je zal ontdekken dat dit lukt.  
        
### Task 9: Configure a Static route using an exit interface.  
Step 1: Configure a static route on R3.  
* In privileged EXEC mode van R3, typ conf term en hit enter.  
* Typ ip route 172.16.2.0 255.255.255.0 serial 2/0.  
           
Step 2: View the routing table to verify the new static route entry.
* Met het commando show ip route kan je de routing table weergeven.  
* Je zou moeten opmerken dat er een nieuwe Static route is toegevoegd.  
* Gebruik het commando show running-config om te verifieren dat de static routes geconfigureerd zijn.  
           
             
Step 3: On R2, configure another static route.  
* In privileged EXEC mode van R2, typ conf term en hit enter.  
* Typ ip route 172.16.3.0 255.255.255.0 serial 2/0  
          
Step 4: View the routing table to verify the new static route entry.  
* Ondertussen weten we dat dit kan met het commando show ip route.  
          
Step 5: Use ping to check connectivity between the host PC2 and PC1.  
* Dit zal falen, en wel omdat R2 alle netwerken in de topology kent, maar dit niet wil zeggen dat de netwerken R2 kennen.  
        
          
### Task 10: Configure a default static route  
Step 1: configure the R1 reouter with a default route.  
* In privileged EXEC mode van R3, typ conf term en hit enter.  
* Typ ip route 0.0.0.0 0.0.0.0 172.16.2.2 in en hit enter.  
          
Step 2: View the routing table to verify the new static route entry.  
* Wederom commando show ip route gebruiken.  
         
           
Step 3: Use ping to check connectivity between the host PC2 and PC1.  
* PC2 zal kunnen pingen naar PC1.  
* PC3 zal NIET kunnen pingen naar PC1.  
           
             
### Task 11: Configure a summary static route.  
Step 1: Configure the summary static route on the R3 router.  
* In privileged EXEC mode van R3, typ conf term en hit enter.  
* Typ ip route 172.16.0.0 255.255.252.0 192.168.1.2 in en hit enter.  

Step 2: Verify that the summary route is installed in the routing table.  
* Indien je dit commando nog niet kent, heb je het geheugen van een cavia.  
* Show ip route.  

Step 3: Remove static routes on R3.  
* In privileged EXEC mode van R3, typ conf term en hit enter.  
* Typ no ip route 172.16.1.0 255.255.255.0 192.168.1.2 en hit enter.  
* Typ no ip route 172.168.2.0 255.255.225.0 serial 2/0 en hit enter.  

Step 4: Verify that the routes are no longer in the routing table.  
* Show ip route als commando gebruiken.  

Step 5: Use ping to check connectivity between the host PC3 and PC1  
* Het werkt, je kan pingen van PC3 naar PC1.  
           
            
     
    
        
          

