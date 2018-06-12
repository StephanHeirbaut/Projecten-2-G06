# Testplan - IT park automatiseren 

Op een windows 2012 R2 Server GUI. Liefst een nieuwe server, met geen andere rollen en commando's op. Zeker niet die van de Wisa gebruiken want die heeft extra dingen erop staan die je niet nodig hebt. 

Je gaat er een AD domein controller van maken. 
Als dit gebeurt is dan moet je als eerste de Windows Deployment Services role toevoegen. 

![image](https://cloud.githubusercontent.com/assets/17159222/26245799/28e73086-3c96-11e7-8322-2d57affa25e8.png)

![image](https://cloud.githubusercontent.com/assets/17159222/26245823/4145688c-3c96-11e7-8511-235cbbd1c49d.png)

![image](https://cloud.githubusercontent.com/assets/17159222/26245836/540b001c-3c96-11e7-815e-e5f20b0e17a9.png)

![image](https://cloud.githubusercontent.com/assets/17159222/26245845/6647e3c6-3c96-11e7-896e-8c52b0015aff.png)

Er moeten geen features toevoegd worden. 
![image](https://cloud.githubusercontent.com/assets/17159222/26245860/8347a4ac-3c96-11e7-9704-e0222fc4721b.png)

Dit gewoon default laten staan.   

Het makkelijkste om MDT en ADK te installeren. Is dat je de .exe op je laptop download en dan in een share map zet.   
Om een share folder aan te maken doe je het volgende.   
Dit doe je eerst guest addition te installeren op je machine. Je insert de de 'cd' van guest additions via Devices/insert guest additins CD image.   
Dan installeer je deze gewoon.   
Als je dit gedaan hebt dan Reboot je de machine.   
Dan kan je terug bij Devices op Shared Folders klikken. Daar op Shared Folders Settings. Dan krijg je volgend scherm.   

![image](https://cloud.githubusercontent.com/assets/17159222/26246035/642f1388-3c97-11e7-8198-d7457350aa30.png)  

Dan voeg je een shared folder toe. Daar geef je het path van de folder mee die je wilt sharen.   

![image](https://cloud.githubusercontent.com/assets/17159222/26246072/87236f56-3c97-11e7-892c-b2acf4791829.png)  

Als dit gebeurt is dan kan je via network aan de map die je geshared hebt.   

![image](https://cloud.githubusercontent.com/assets/17159222/26246136/d94020fe-3c97-11e7-9c2b-23ac5ee9d5ad.png)  

Dan kan je nu MicrosoftDeployment Toolkit 2013 installeren. Hier laat je gewoon alles default staan.   
Als dit ingestalleerd is dan installeer je de ADK.   

![image](https://cloud.githubusercontent.com/assets/17159222/26246177/13c4a0b0-3c98-11e7-9c9b-dbccef0054f5.png)  
Enkel Deployment tools, Windows Preinstallation Environment en User State migration tool installeren. Dit kan even duren.

![image](https://cloud.githubusercontent.com/assets/17159222/26246204/2a244270-3c98-11e7-8da9-d1da1875fd8c.png)  

Als alles is geinstalleerd, dan ga je naar Deployment Workbench. 
Dan maak je een nieuwe Deployment share aan. 

![image](https://cloud.githubusercontent.com/assets/17159222/26246353/fcb7d8a0-3c98-11e7-90cc-f534748b3021.png)

Je vult je eigen share naam in, die nuttig is. De rest laat je allemaal default staan.   

Als dit gebeurt is dan voeg je een Operating System toe. 

![image](https://cloud.githubusercontent.com/assets/17159222/26246409/462d7562-3c99-11e7-893e-1a6f42e56062.png)  

Full set of source files gebruiken   

![image](https://cloud.githubusercontent.com/assets/17159222/26246423/577aa36c-3c99-11e7-8388-aa2afc624bab.png)  

Dan geef je het path weer waar de iso staat. Deze kopieer je best uit de netwerkfolder naar het bureaublad. (Je zet deze dus ook in de shared folder, die je hier boven hebt aangemaakt)  
![image](https://cloud.githubusercontent.com/assets/17159222/26246430/66ad0000-3c99-11e7-9e07-f000c00c7fbf.png)  

Geef het een nuttige naam.   
Nu we een OS hebben toegewezen, moet je bij MDT ook een Task Sequence instellen.   
Dit is voor de disk te formatteren, de drivers te installeren. Dit hoef je dus allemaal niet meer handmatig te doen.     
![image](https://cloud.githubusercontent.com/assets/17159222/26246586/3e6f667c-3c9a-11e7-852f-ac2c0e258928.png)  
 
Je geeft het een ID en naam. Kies een naam met betekenis. Want deze zal zo getoond worden.
![image](https://cloud.githubusercontent.com/assets/17159222/26246605/54a84940-3c9a-11e7-8eba-a5a848bbd49f.png)   

Dan moet je het pakket kiezen die je wilt uitvoeren. Wij gaan werken met een Standard Client Task Sequence. 
Dan kies je een Operation system, uit de lijst van de OS'en die je hebt toegevoegd.

![image](https://cloud.githubusercontent.com/assets/17159222/26246630/723d2d0e-3c9a-11e7-99d2-f060f541def6.png)

Je kan daar een product key meegeven. In bedrijven zal dit moeten, wij gebruiken dit niet omdat we gewoon testen. 

![image](https://cloud.githubusercontent.com/assets/17159222/26246645/860c2628-3c9a-11e7-9475-038da618caad.png)  

Dan geef je naam mee en de organisatie. De IE home page laat je gewoon leeg.   

![image](https://cloud.githubusercontent.com/assets/17159222/26246663/99ce94f2-3c9a-11e7-85b7-dd2287c225e3.png)  

Dan geef je een default wachtwoord mee, deze kan later nog verandert worden.

![image](https://cloud.githubusercontent.com/assets/17159222/26246684/ae0ad278-3c9a-11e7-945c-73df1188ef83.png)  

Voor je echt via het netwerk kan booten 
Je moet eerst op de MDT server de Deploymentshare map sharen. Dit doe je door properties op de map zelf. 
![image](https://cloud.githubusercontent.com/assets/17159222/26246732/e579fec8-3c9a-11e7-9c31-429b850d286c.png)

![image](https://cloud.githubusercontent.com/assets/17159222/26246744/fa3f9fc0-3c9a-11e7-8987-6d5b33c61cf1.png)  

Je shared deze map voor iedereen. Zorg ervoor dat je op ADD klikt, anders wordt dit niet geshared met iedereen.  
![image](https://cloud.githubusercontent.com/assets/17159222/26246754/08ddd95c-3c9b-11e7-89b8-b260059a6ad6.png)  

Als dit gebeurt is ga je terug naar de DeploymentWorkbench. 
Dan ga je naar de gemaakt Deploymentshare. Klik je op properties. 

![image](https://cloud.githubusercontent.com/assets/17159222/26246770/29ef1dd6-3c9b-11e7-99e0-f9a54f0418a1.png)

Dan ga je naar het tabblad rules. 
Dan klik je op edit bootstrap.ini 


![image](https://cloud.githubusercontent.com/assets/17159222/26246784/3b58bf8c-3c9b-11e7-8738-5dc0f8c3e55b.png)  

Zorg dat de file hetzelfde is al op de volgende screenshot. Enkel de Deployroot met je aanpassen, aan het path van de geshared Deployment file. 

![image](https://cloud.githubusercontent.com/assets/17159222/26246882/a192b5dc-3c9b-11e7-85f0-84212b55d753.png)

Als dit gedaan dan, zorg je er voor dat het scherm bij rules. Het eruit ziet als de volgende screenshot. 
![image](https://cloud.githubusercontent.com/assets/17159222/26246969/07d1c432-3c9c-11e7-86df-af6945f15380.png)  
 
[Applicaties stuk nog schrijven] 

Voor we verder kunnen updaten we de deployment share. 
![image](https://cloud.githubusercontent.com/assets/17159222/26247003/367346b2-3c9c-11e7-8c3a-c8f11bf938de.png)

Dan klik je Regenerate boot images. 

![image](https://cloud.githubusercontent.com/assets/17159222/26247011/48e200e0-3c9c-11e7-80a3-a5a6d917b0e4.png)  
Dit kan even duren. 

Terwijl dit aan het lopen is kan je Windows Deployment services configueren.  
Dit doe je door op servers te klikken en dan zie je bij je servernaam een driehoekje staan. Deze gaan we configueren.

![image](https://cloud.githubusercontent.com/assets/17159222/26247095/9925bdf8-3c9c-11e7-88c5-253fa4bb3bcb.png)
 
We gaan werken met een standalone server. 

![image](https://cloud.githubusercontent.com/assets/17159222/26247102/a5103f44-3c9c-11e7-9b2a-d0a2b0f5303c.png)


Dan bij PXE Server Initial Settings: Zetten we het op Responds to all clienst computers (known and unknown). 

![image](https://cloud.githubusercontent.com/assets/17159222/26247128/bf7d4aac-3c9c-11e7-87df-fa8467868eac.png)  

Dan klik je next en dan zorg je dat Add Images to the server now uit. 
![image](https://cloud.githubusercontent.com/assets/17159222/26247195/074e8dc8-3c9d-11e7-9dd1-0beefe1cf993.png)  

Hierna moet je een boot image toevoegen. Deze voeg je niet toe via, direct toevoegen. Je gaat uit de wizard.  
Dan klik je op Add Boot Images om eraan toe te voegen. 
![image](https://cloud.githubusercontent.com/assets/17159222/26247231/3e6fabac-3c9d-11e7-8c24-600b7727c751.png)  


Kijk eerst of Regenerate boot images gedaan is. Als dit gedaan is dan kan je de boot image toevoegen. 
Je vind de boot image, die je net gegeneerd hebt terug (default) in de C drive onder DeploymentShare\Boot. 
Je kiest dan voor LiteTouchPE_x86.wim. De rest laat je op default staan. 

![image](https://cloud.githubusercontent.com/assets/17159222/26247253/590db21a-3c9d-11e7-9a00-c5c12d47241f.png)

Dit doe je ook voor de LiteTouchPE_x64.wim 

Dan klik je rechtmuisknop op je server, properties.
Het belangrijkste is dat je de Boot nakijkt. 
Je moet er voor zorgen dat de bovenste optie is aangeklikt. 
Dan voeg je de paden toe van de boot images, bij x86 en x64 architecture. 
Ook het path toevoegen bij x86 (UEFI) en x64 (UEFI) architecture. 
De rest van de properties laat je default. 

![image](https://cloud.githubusercontent.com/assets/17159222/26247295/8cabee34-3c9d-11e7-89df-758e91fcc9c0.png)  

![image](https://cloud.githubusercontent.com/assets/17159222/26247308/9d88a5da-3c9d-11e7-9ba7-9f07db18a9ef.png)  

Dit was alles wat je in de virtuele machines moest doen.   
Voor PXE boot te kunnen gebruiken in virtual box. Moet je bij Virtualbox 2 netwerken aanmaken. Dit doe je bij File -> Preference
Dan naar Network. Daar zie je 2 tabbladen met NAT network en Host-only network.   
![image](https://cloud.githubusercontent.com/assets/17159222/26247345/c4712eba-3c9d-11e7-9b8e-988a87dcbf74.png)

Je maakt een NAT Networks aan. Dit doe je door op het groene ding met plusje te klikken. Deze word dan aangemaakt. 
Dan ga je naar het icoontje van de schroevendraaier. Daar stel je in dat Supports DHCP. 
Als dit gebeurt is. Ga je naar de tab Host-only network. Je maakt er eerst 1 aan en dan configueer je die. 
Je gaat naar de tab DHCP Server en Enabled die server. Zorg ervoor dat het server address in hetzelfde subnet zit als het NAT network. 
Als dit gebeurt is, zorg je dat je in je MDT server een NAT network en een host only network hebt. En bij je user machine  hostonly netwerk. 

Normaal zou je nu kunnen booten vanaf het netwerk. Je doet F12 bij virtual box. Dan duw we l voor de LAN connectie. 
Als de dhcp getoond word, zal er F12 terug staan op het scherm doe dit.

![capture](https://cloud.githubusercontent.com/assets/17159222/26247490/5fc98a4c-3c9e-11e7-8a69-40ca2b050ad8.PNG)

Dan krijg je een scherm met 2 opties een x86 en x64. 
Je kiest voor 32 bit pc x86 en voor 64 bit pc x64. 

Als je dit hebt gedaan dan start de microsoft Deployment Toolkit op.
![image](https://cloud.githubusercontent.com/assets/17159222/26247530/981df090-3c9e-11e7-8fb7-d47dc07526c3.png)  

De foutmelding die ik krijg.   
![image](https://cloud.githubusercontent.com/assets/17159222/26247584/d51cbe18-3c9e-11e7-8b78-779226c6a40f.png)

-------------------------------------------------------------------------------------------------------------------------------------
Geraadpleegde bronnen: 
https://l.messenger.com/l.php?u=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3D6Bllzv_qayM&h=ATPKB2OozJ_HeoLWW4UNk2cQfCyguM1V_ekxMOUemveu-F8nYVhJMbGMY83iS6T8bnRz81DZU9FGvLyaTykRHC0SIOglOYgTxEOuZpAdCJbVi3CmXgcS3DjR8pBRiCJ7e_PicVs  

https://www.virtualbox.org/manual/ch06.html  

https://docs.microsoft.com/en-us/windows/deployment/deploy-windows-mdt/deploy-a-windows-10-image-using-mdt#a-href-idsec01astep-1-configure-active-directory-permissions  

http://www.techrepublic.com/article/how-to-deploy-applications-with-microsoft-deployment-toolkit/

https://forums.virtualbox.org/viewtopic.php?f=9&t=17747

https://mdtguy.wordpress.com/2014/02/17/installing-the-latest-java-re-msi-with-mdt-2013/

http://c-nergy.be/blog/?p=6472

https://community.spiceworks.com/topic/1253384-mdt-2013-update-1-automate-deployment-share-prompt-on-client

https://social.technet.microsoft.com/Forums/en-US/9fe338d3-1df9-4fd5-8833-3a4f9495a4f1/invalid-credentials-network-path-was-not-found-mdt-2012-sp1?forum=mdt

https://www.youtube.com/watch?v=J63zmnvCvDs

https://social.technet.microsoft.com/Forums/en-US/414423ac-2dd9-4689-a3e4-ecaaafb20bd0/mdt-2013-update-1-issues-connecting-to-deployroot?forum=mdt 
