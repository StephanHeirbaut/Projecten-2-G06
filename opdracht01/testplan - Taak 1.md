# Testplan taak 1: Establishing a Console Session with Tera Term 

Part 1: Acces a Cisco Switch through the Serial Console Port 
  Step 1: Connect a Cisoc switch and computer using a rollover console cable 
  
    a. Connect the rollover console cable to the RJ-45 console port of the switch. 
    
    Als eerst geef je de pc en de switch een passende naam. In de labo noemt de PC -> PC-A en de switch, gewoon switch. 
    We gebruiken switch 2960 en een Generic Desktop.
    Je verbindt de switch met console kabel met de PC. 
    Bij de computer is dit in de poort met naam RS 232.
    Bij de Switch is dit in de poort met naam Console.  
      
    b. Connect the other cable end to the serial COM port on the computer. 
    Bij packet tracer moet je de devices niet opstarten. 
    Bij fysieke uitwerking moet je natuurlijk wel de powerkabel van de Switch insteken. 
    
  Step 2: Configure Tera Term to establish a console session with the switch 
  
    a. Start Tera Term by clicking the Windows Start button located in the task bar. Locate Tera Term under All Programs. 
    
    Fysieke uitwerking: 
    Bij de school pc's staat tera term al gedownload. Anders downloaden via link http://logmett.com/index.php?/download/free-downloads.html
    
    
    Packet tracer: 
    Tera Term kan niet worden gebruikt op Packet Tracer. Hiervoor gebruikt je de terminal van de pc.
    Je klikt hiervoor op de computer, gaat naar de tab Desktop. Als je hier bent dan klik je op het icoon van Terminal.
    Dan kom je ook bij Terminal configuation. 
    
    Je zorgt dat het als volgt ingesteld staan:  
    Bits Per Second : 9600
    Data bits : 8 
    Parity: None
    Stop Bits: 1
    Flow Control: None
    
    Als deze zo staan ingesteld klik je op ok. Dat zou dan je terminal geven. 
    Als je dan op return klikt, dan kan je commando's in je switch ingeven. Dan kan je overgaan naar PART 2. 
    
    b. 
    Fysieke uitwerking:
    Als je Tera Term opent dan krijg je een pop-up. Deze moet ingesteld staan zoals hieronder:
    
![teraterm_popup](https://cloud.githubusercontent.com/assets/17174277/23121872/64d8404a-f762-11e6-8842-a7e483ec25a0.png)
    
    
    c. 
    
    Fysieke uitwerking: 
    Hierna klik je op het tabblad Setup en daar klik je dan op Serial port.
    Je stelt dit in als hieronder op de afbeelding.
    
 ![teraterm_serial](https://cloud.githubusercontent.com/assets/17174277/23121967/b66bccce-f762-11e6-96fe-5afca9bfb341.png)
    
    d. 
    
    Fysieke uitwerking: 
    Als je switch is opgestart dan krijg je het volgend scherm.
    
![resultaat_switch](https://cloud.githubusercontent.com/assets/17174277/23122053/0df3285c-f763-11e6-8607-099c578c67a4.png)
  
  
-------------------------------------------------------------------------------------------------------------------  

Part 2: Display and Configure Basic Device Settings 
  Step 1: Display the switch IOS image version. 
  
    a. After the switch has completed its startup process, the following message displays. Enter n to continue. 
    
    Bij de vraag: would you like to enter the initial configuration dialog? [yes/no]: n invullen 
    (Deze vraag krijg je NIET In pakket Tracer) 
  
    b. Het volgend commando moet je in EXEC mode doen. Dit zie je adhv het > achter switch. 
    Dus als er Switch> staat ben je in de juiste mode bezig. 
    
    Er wordt gevraagd om dit commando uit te voeren: show version. 
    Hierdoor zie je de versie van het OS van de switch.
    Met enter wordt lijn per lijn getoond. Doe je spatie dan wordt alles getoond. 
    
    Je zit dan een tabel met switch, ports, model, etc staan. 
    Hierin kan je zien welk model en welk OS versie er op de switch staat.
    De image bij was C2960-LANBASE-M.

  Step 2: Configure the clock 
    
    Nog altijd in EXEC mode
  
    a. Om de klok te tonen gebruik je het commando: show clock. 
    Standaard in pakket tracer is deze ingesteld op 1 maart 1993
    
    b. We gaan nu naar privileged EXEC mode. Dit doe je met het volgend command: enable
    Als er een # achter switch staat dan ben je in die mode. 
    
    c. Nu gaan we kijken naar de configuraties van de clock. 
    Voor het volgend commando in: clock set ? het vraagteken toont wat er na het commando nog moet ingevuld worden 
    
    Voer dan de volgende commando's uit. (Dit kan je natuurlijk ook doen met de huidige datum en tijd) 
    clock set 15:08:00 ?
    clock set 15:08:00 Oct 26 ?
    clock set 15:08:00 Oct 26 2012 ? 
    
    d. Voer dan het commando show clock uit. Hierdoor kan je zien of je clock juist is ingesteld. 

-------------------------------------------------------------------------------------------------------------------  

Part3: (Optional) Access a cisco Router using a Mini-USB Console Cable (Kan enkel Fysieke gedaan worden) 
  

   Omdat er op school geen mini-USB console cable aanwezig zijn gebruiken we een gewone console cable.
   Dus Step 1 tot Step 3 kan je niet uitvoeren 

  Step 4 : Set up the physical connection with a mini-USB cable
    
    a. Kan niet gedaan worden 
    
    b. Open tera term 
    Dan krijg je een popup deze stel je in als de afbeelding hieronder. 
    
![teratarmRouter](https://cloud.githubusercontent.com/assets/17174277/23122481/a9b8253e-f764-11e6-9f1b-2a90171fa927.png)
    
    
  
Auteur(s) testplan: Jodie De Pestel 
