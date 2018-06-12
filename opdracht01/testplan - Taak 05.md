# Testplan taak 5: opdracht-01-Packettracer - basisconfiguratie Switch

Objectives:  
  *    Configure hostnames and IP addresses on two Cisco Internetwork Operating System (IOS) switches using the command-line interface (CLI).
  
    1) Verbind de PC "Manager"(poort RS 232) en de switch Room-145(console poort) met een console kabel.  
    2) Ga in de PC "Manager" naar de tab Desktop en ga naar de Terminal.  
    3) Laat de instellingen staan en druk op "OK".  
    4) Druk op "ENTER"  
    5) Voer "enable" in.  
    6) Voer "config terminal" in.  
    7) Voer "hostname Room-145" in.  
    8) Voer "int vlan 1" in.  
    9) Voer "ip address 10.10.10.100 255.255.255.0" in.  
    10) Voer "no shutdown" in.  
    11) Druk "ENTER".  
    12) Voer "exit" in.  
    
  *  Use Cisco IOS commands to specify or limit access to the device configurations.  
    1) Voer "enabe secret 6EBUp" in.  
    2) Voer "line con 0" in.  
    3) Voer "password xAw6k" in.  
    4) Voer "login" in.  
    5) Voer "exit" in.  
    6) Voer "line vty 0 4" in.  
    7) Voer "password xAw6k" in.  
    8) Voer "login" in.  
    9) Voer "exit" in.  
    10) Voer "service password-encryption" in.  
    11) Voer "banner motd #warning, authorized acces only!#" in.  
    12) Voer "exit" in.  
    13) Druk "ENTER".  
    
  * Use IOS commands to save the running configuration.  
    1) Voer "copy running-config startup-config" in.  
    2) Voer "ENTER" in.  
    
  * herhaal bovenstaande stappen maar verbind de PC "Reception"(poort RS 232)
    en de switch Room-146(console poort) met een console kabel
    en gebruik voor de hostname "Room-146" en ip adres 10.10.10.150 255.255.255.0  
    
  * Configure two host devices with IP addresses.  
    1) Ga in de PC "Manager" naar de tab Desktop en ga naar de IP Configuratie.  
    2) Geef in het veld IP Address "10.10.10.4" in.  
    3) Geef in het veld Subnet Mask "255.255.255.0" in.  
    4) Sluit het venster.
    5) Ga in de PC "Reception" naar de tab Desktop en ga naar de IP Configuratie.  
    6) Geef in het veld IP Address "10.10.10.5" in.  
    7) Geef in het veld Subnet Mask "255.255.255.0" in.  
    8) Sluit het venster.  
    
  * Verify connectivity between the two PC end devices.  
  1) Ga in de PC "Manager" naar de tab Desktop en ga naar de Command prompt.  
  2) Voer "ping 10.10.10.5" in. normaal zou je reply's moeten krijgen.
     
Auteur(s) testplan: Bert Provoost.


