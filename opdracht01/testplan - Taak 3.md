# Testplan taak 3: Lab - Building a Switch and Router Network

Part 1: Set Up Topology and Initialize Devices.  
  Step 1: Cable the network as shown in the topology.  
  
    a. Attach the devices shown in the topology diagram, and cable, as necessary.  
    
      Wij gebruiken voor PC-A en PC-B gewoon generic desktops. De switch is een CISCO 2960 switch
      en de Router is een CISCO 1941 router. De bekabeling van PC-A poort FastEthernet0 naar de switch poort F0/6 en
      van switch-poort F0/5 naar router G0/1 is copper straight  
      through en de bekabeling van router poort G0/0 naar PC-B FastEthernet0 is een crossover.
      
Part 2: Configure Devices and Verify Connectivity.  
  Step 1: Assign static IP information to the PC interfaces.
  
    a. Configure the IP address, subnet mask, and default gateway settings on PC-A.  
      IP-adres PC-A instellen als 192.168.1.3 – 255.255.255.0 via desktop -> IP Configuration.   
      
    b. Configure the IP address, subnet mask, and default gateway settings on PC-B.
      IP-adres PC-B instellen als 192.168.0.3 – 255.255.255.0 via desktop -> IP Configuration.  
      
    c.Ping PC-B from a command prompt window on PC-A. 
      Open de Command promt in PC-A.
      Voer 'ping 192.168.0.1' in.
      Je krijgt dan een error: Request timed out.  
      
  Step 2: Configure the router.  
  
    a. Console into the router and enable privileged EXEC mode.      
      Start de Command Line Interface op van de router.  
      Druk op 'ENTER'.  
      Voer 'enable' in.  
      
    b. Enter configuration mode.    
      Voer ‘configure terminal’ in.  
      
    c. Assign a device name to the router.      
      Voer ‘hostname r1’ in.  
      
    d. Disable DNS lookup to prevent the router from attempting to translate incorrectly entered commands as  
    though they were host names.      
      Voer ‘no ip domain-lookup’ in.  
      
    e. Assign class as the privileged EXEC encrypted password.      
      Voer ‘enable secret class’ in.  
      
    f. Assign cisco as the console password and enable login.      
      Voer ‘line con 0’ in.  
      Voer ‘password cisco’ in.  
      Voer ‘login’ in.  
      Voer ‘exit’ in.  
      
    g. Assign cisco as the VTY password and enable login.      
      Voer ‘line vty 0 4’ in.  
      Voer ‘password cisco’ in.  
      Voer ‘login’ in.  
      Voer ‘exit’ in.  
      
    h. Encrypt the clear text passwords.      
      Voer ‘service password-encryption’ in.  
      
    i. Create a banner that warns anyone accessing the device that unauthorized access is prohibited.      
      Voer ‘banner motd #authorized access only!#’ in.  
      
    j. Configure and activate both interfaces on the router.     
      Voer ‘interface g0/0’ in.  
      Voer ‘ip address 192.168.0.1 255.255.255.0’ in.  
      Voer ‘no shutdown’ in.  
      Voer ‘exit’ in.  
      Voer ‘interfce g0/1’ in.  
      Voer ‘ip address 192.168.1.1 255.255.255.0’ in.  
      Voer ‘no shutdown’ in.  
      Voer ‘exit’ in.  
      
    k. Configure an interface description for each interface indicating which device is connected to it.      
      Voer ‘interface g0/0’ in.  
      Voer ‘description Verbonden met PC-B’ in.  
      Voer ‘end’ in.  
      Voer ‘configure terminal’ in.  
      Voer ‘interface g0/1’ in.  
      Voer ‘description Verbonden met S1’ in.  
      Voer ‘end’ in.  
      
    l. Save the running configuration to the startup configuration file.      
      Voer ‘copy running-config startup-config’.  
      Druk op 'ENTER'.  
      
    m. Set the clock on the router.      
      clock set 12:36:30 19 19 feb 2017.  
      
    n. Ping PC-B from a command prompt window on PC-A.      
      Ping van PC-A naar PC-B.  
      
Part 3: Display Device Information.  
  Step 1: Retrieve hardware and software information from the network devices.  
  
    a. Use the show version command to answer the following questions about the router.  
      Start de Command Line Interface op van de router.  
      Druk op 'ENTER'.  
      Log in met het password: “cisco".  
      Geef het commando “show version” in.  

    b. Use the show version command to answer the following questions about the switch.  
      Start de Command Line Interface op van de switch.  
      Druk op 'ENTER'.  
      Voer ‘show version’ in.  

  Step 2: Display the routing table on the router.  
  
    a. Use the show ip route command on the router to answer the following questions.  
      Start de Command Line Interface op van de router.  
      Druk op 'ENTER'.  
      Log in met het password: “cisco".  
      Voer ‘show ip route’ in.  
      
  Step 3: Display interface information on the router.  
  
    a. Use the show interface g0/1 to answer the following questions.  
      Start de Command Line Interface op van de router.  
      Druk op 'ENTER'.  
      Voer ‘show interface G0/1’ in.  
      Voer ‘show ip interface brief’ in.  

 Step 4: Display a summary list of the interfaces on the router and switch.   
 
    a. Enter the show ip interface brief command on the router.  
      Start de Command Line Interface op van de router.  
      Druk op 'ENTER'.  
      Voer ‘show ip interface brief’ in.  
      
    b. Enter the show ip interface brief command on the switch.  
      Start de console van de router.  
      Voer ‘show ip interface brief’ in.  
    
Auteur(s) testplan: Stephan Heirbaut & Bert Provoost.


