# cheat sheet basiscommando's 


   Router Modes:  

         Router>: User mode = Limited to basic monitoring commands  
         Router#: Privileged mode (exec-level mode) = Provides access to all other router commands  
         Router(config)#: global configuration mode = Commands that affect the entire system  
         Router(config-if)#: interface mode = Commands that affect interfaces  
         Router(config-subif)#: subinterface mode = Commands that affect subinterfaces  
         Router(config-line)#: line mode = Commands that affect in lines modes (console, vty, aux…)  
         Router(config-router)#: router configuration mode  
   
   Changing switch hostname:  

         Switch(config)# hostname SW1  
   
   Configuring passwords:  

         SW1(config)# enable secret cisco    ! MD5 hash  
         SW1(config)# enable password notcisco    ! Clear text  
      
   Securing console port:  

         SW1(config)# line con 0  
         SW1(config-line)# password cisco  
         SW1(config-line)# login  
      
   Securing terminal lines: 

         SW1(config)# line vty 0 4 
         SW1(config-line)# password cisco  
         SW1(config-line)# login  
      
   Encrypting passwords:  

         SW1(config)# service password-encryption  
      
   Configuring banners:  

         SW1(config)# banner motd $  
         -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-  
         UNAUTHORIZED ACCESS IS PROHIBITED  
         -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-  
         $  
      
   Giving the switch an IP address:  

         SW1(config)# interface vlan 1  
         SW1(config-if)# ip address 172.16.1.11 255.255.255.0    ! or DHCP  
         SW1(config-if)# no shutdown  
      
   Setting the default gateway:  

      SW1(config)# ip default-gateway 172.16.1.1  
      
   Saving configuration:  

         SW1# copy running-config startup-config  
         Destination filename [startup-config]?    ! Press enter to confirm file name.  
         Building configuration…  
         [OK]  

         ! Short for write memory.  
         SW1# wr  
         Building configuration…  
         [OK]  
         
   Working environment:  

      name lookup, history, exec-timeout and logging behavior…, also valid for line con 0.  

         SW1(config)# no ip domain-lookup  
         SW1(config)# line vty 0 4  
         SW1(config-line)# history size 15  
         SW1(config-line)# exec-timeout 10 30  
         SW1(config-line)# logging synchronous  
         Configuring switch to use SSH:  

   Configure DNS domain name:  
   
         SW1(config)# ip domain-name example.com  
         
   Configure a username and password:  
   
         SW1(config)# username admin password cisco  
         
   Generate encryption keys:  
   
   The size of the key modulus in the range of 360 to 2048  

         SW1(config)# crypto key generate rsa
         How many bits in the modulus [512]: 1024  
         
   Define SSH version to use:  
   
         SW1(config)# ip ssh version 2  
         
   Enable vty lines to use SSH:  
   
         SW1(config)# line vty 0 4  
         SW1(config-line)# login local  
         ! You can set vty lines to use only telnet or only ssh or both as in the example.  
         SW1(config-line)# transport input telnet ssh  
   
   Aliases:  

   Used to create shortcuts for long commands.  

         SW1(config)# alias exec c configure terminal  
         SW1(config)# alias exec s show ip interface brief  
         SW1(config)# alias exec sr show running-config  
   
   Description, speed and duplex:  

         SW1(config)# interface fastEthernet 0/1  
         SW1(config-if)# description LINK TO INTERNET ROUTER  
         SW1(config-if)# speed 100    ! Options: 10, 100, auto  
         ! The range keyword used to set a group of interfaces at once.  
         SW1(config)# interface range fastEthernet 0/5 – 10  
         SW1(config-if-range)# duplex full (options: half, full, auto)  
         
   Verify Basic Configuration:  

   Shows information about the switch and its interfaces, RAM, NVRAM, flash, IOS, etc.  
   
         SW1# show version  
         
   Shows the current configuration file stored in DRAM.  
   
         SW1# show running-config  
         
   Shows the configuration file stored in NVRAM which is used at first boot process.  
   
         SW1# show startup-config  
         
   Lists the commands currently held in the history buffer.  
   
         SW1# show history  
         
   Shows an overview of all interfaces, their physical status, protocol status and ip address if assigned.  
   
         SW1# show ip interface brief  
         
   Shows detailed information about the specified interface, its status, protocol, duplex, speed, encapsulation, last 5 min traffic.  
   
         SW1# show interface vlan 1  
         
   Shows the description of all interfaces  
   
         SW1# show interfaces description  
         
   Shows the status of all interfaces like connected or not, speed, duplex, trunk or access vlan.  
   
         SW1# show interfaces status  
   Shows the public encryption key used for SSH.  
   
         SW1# show crypto key mypubkey rsa  
   Shows information about the leased IP address (when an interface is configured to get IP address via a dhcp server)  
   
         SW1# show dhcp lease  
         
   Configuring port security:  

   Make the switch interface as access port:  
   
         SW1(config-if)# switchport mode access  
         
   Enable port security on the interface:  
   
         SW1(config-if)# switchport port-security  
   Specify the maximum number of allowed MAC addresses:  
   
         SW1(config-if)# switchport port-security maximum 1  
         
   Define the action to take when violation occurs:  
   
         SW1(config-if)# switchport port-security violation shutdown    ! options: shutdown, protect, restrict  
         
   Specify the allowed MAC addresses:  
   
   The sticky keyword is used to let the interface dynamically learns and configures the MAC addresses of the currently connected hosts.  

         SW1(config-if)# switchport port-security mac-address 68b5.9965.1195    ! options: H.H.H, sticky  
         
   Verify and troubleshoot port security:  

   Shows the entries of the mac address table:  
   
         SW1# show mac-address-table  
         
   Overview of port security of all interfaces:  
   
         SW1# show port-security  
         
   Shows detailed information about port security on the specified interface:  
   
         SW1# show port-security interface fa0/5  
         
   Configuring VLANs:  

   Create a new VLAN and give it a name:  

         SW1(config)# vlan 10  
         SW1(config-vlan)# name SALES  
         
   Assign an access interface to access a specific VLAN:  

         SW1(config)# interface fastEthernet 0/5  
         SW1(config-if)# switchport mode access  
         SW1(config-if)# switchport access vlan 10  
         
   Configuring an auxiliary VLAN for cisco IP phones:  

         SW1(config)# interface fastEthernet 0/5  
         ! accessing vlan 10 (data) and 12 (VoIP)  
         SW1(config-if) #switchport access vlan 10  
         SW1(config-if) #switchport voice vlan 12  
         
   Configuring Trunks:  

         SW1(config)# interface fastEthernet 0/1  
         SW1(config-if)# switchport mode trunk    ! options: access, trunk, dynamic auto, dynamic desirable  
         SW1(config-if)# switchport trunk allowed vlan add 10    ! options: add, remove, all, except  
         
   Securing VLANs and Trunking:  

   Administratively disable unused interfaces:  
   
         SW1(config-if)# shutdown  
         
   Prevent trunking by disabling auto negotiation on the interface:  
 
         SW1(config-if)# nonegotiate    ! or hardcode the port asan access port  
         SW1(config-if)# switchport mode access  
         
   Assign the port to an unused VLAN:  
   
         SW1(config-if)# switchport access vlan 222  
         
   Configuring VTP:  

   Configure VTP mode:  
   The transparent VTP mode is used when an engineer wants to deactivate VTP on a particular switch  

         SW1(config)# vtp mode server    ! options: server, client, transparent  
         
   Configure VTP domain name:  
   
         SW1(config)# vtp domain EXAMPLE    ! case-sensitive  
         
   Configure VTP password (optional):  
   
         SW1(config)# vtp password cisco    ! case-sensitive  
   Configure VTP pruning (optional):  
   
         SW1(config)# vtp pruning    ! only works on VTP servers   
         
   Enable VTP version 2 (optional):  
   
         SW1(config)# vtp version 2  
         
   Verify and troubleshoot VLANs and VTP:  

   Lists information about administrative setting and operation status of interface:  
   
         SW1# show interfaces if switchport  
         
   Lists all the trunk ports on a switch including the trunk allowed VLANs:  
   
         SW1# show interfaces trunk  
         
   Lists information about the VLANs:  
   
         SW1# show vlan {brief | id | name | summary}  
         
   Lists VTP configuration (mode, domain-name, version, etc) and revision number:  
   
         SW1# show vtp status  
         
   Shows the VTP password:  
   
         SW1# show vtp password  
         
   STP optimization:  

   Hard coding the root bridge (changing bridge priority):  

         SW1(config)# spanning-tree vlan 1 root primary  
         SW1(config)# spanning-tree vlan 1 root secondary  
         ! Priority must be a multiply of 4096  
         SW1(config)# spanning-tree [vlan 1]priority 8192  
         
   Changing the STP mode:  
   
         SW1(config)# spanning-tree mode rapid-pvst    ! options: mst, pvst, rapid-pvst  
         
   Enabling portfast and BPDU guard on an interface:  
   Portfast and BPDU guard are enabled only on interfaces connected to end user hosts  

         SW1(config-if)# spanning-tree portfast  
         SW1(config-if)# spanning-tree bpduguard enable  
         
   Changing port cost:  
   
         SW1(config-if)# spanning-tree [vlan 1] cost 25  
         
   Bundling interfaces into an etherchannel:  
   
         SW1(config-if)# channel-group 1 mode on    ! options: auto, desirable, on  
         
   STP verification and troubleshooting:  

   Shows detailed info about STP state:  
   
         SW1# show spanning-tree  
         
   Shows STP info only on a specific port:  
   
         SW1# show spanning-tree interface fa0/2  
         
   Shows STP info only for a specific VLAN:  
   
         SW1# show spanning-tree vlan 1  
         
   Shows info about the root switch:  
   
         SW1# show spanning-tree [vlan 1] root  
         
   Shows info about the local switch:  
   
         SW1# show spanning-tree [vlan 1] bridge  
         
   Show the state of the etherchannels:  
   
         SW1# show etherchannel 1  
         
   Provides informational messages about the changes in the STP topology:  
   
         SW1# debug spanning-tree events  
         
   Enabling or disabling CDP:  

   Enabling CDP globally on a switch:  
   
         SW1(config)# cdp run  
         
   Disabling CDP on a given interface:  
   
         SW1(config-if)# no cdp enable  
         
   Using CDP for network verification and troubleshooting:  

   Shows global information about CDP itself:  
   
         SW1# show cdp  
         
   Shows information about CDP on a specific interface:  
   
         SW1# show cdp interface fa0/2  
         
   Shows information about the directly connected cisco devices including interfaces names capabilities:  
   
         SW1# show cdp neighbors  
         
   Shows detailed information about the neighboring cisco devices including device address and version of IOS they run:  

         SW1# show cdp neighbors detail
         ! OR
         SW1# show cdp entry *
         Shows detailed information about the specified entry only:
         1
         SW1# show cdp entry SW2
    
    
   
   
Auteur(s) checklist: Bert Provoost.
