# Installatieprocedure
## Cisco packets
Na meerdere iteraties en zorgvuldig deliberen over hoeveel en welke gaan we voor 8 standard core packets.
Hierdoor hebben we een pakket voor elke tafel/groep.
Deze packets zullen we dan packet per packet installeren.
Zodoende deze allemaal tezamen te houden, zodat je een goed overzicht hebt waar het ene packet begint en eindigt, en waar de volgende begint.
Al deze componenten zullen we dan verbinden met een patchpaneel, zodoende dat elk component 4 poorten heeft.
Hierdoor zullen de studenten zelfs uitgebreide opgaves zoals opdracht 1 - labo 4 kunnen maken.  
http://honim.typepad.com/files/netacad-promotion_ordering-guide_eligible_equipment_services-list.pdf - Cisco packets


## Racks
Voor de installatie van al deze packets hebben we 4 racks, 2 per lokaal voorzien.
Waarbij we Rack1 voorzien voor de 2 tafels het dichtst bij het bord, en Rack2 voorzien voor de achterste 2 tafels.
Bij de packets zouden er normaal rackmount kits geleverd moeten worden, deze zullen dan wel nog gemonteerde moeten worden op de componenten.
Waarna deze klaar zijn om in de racks gemonteerd te worden.  
https://www.serverkast.com/serverkast/serverkast-en-patchkasten/22u-serverkast-met-glazen-deur-600x600x1200mm.html - Racks

## Kabels
Hierna zullen er alleen nog kabels moeten getrokken worden van elke computer naar de juiste rack.
Zoals eerder aangehaald, zullen er kabels getrokken moeten worden van tafels 1 en 2 naar Rack1, en daarna van tafels 3 en 4 naar Rack2 in beide lokalen.

Als dit allemaal gebeurt is, kunnen de leerlingen met beide netwerken verbonden zijn.
Via de klaspc's met 2 NIC's, kunnen ze gebruik maken van de verbinding die er al is en met de nieuwe kabels moeten ze deze alleen in de pc steken en in de juiste patchpoort waarna ze verbonden ze met hun labo opstelling.
Als een student zijn laptop zou willen gebruiken, kan hij een verbinding aangaan via de WLAN (daarover later mee) en kan hij de kabel naar het patchpaneel in zijn netwerkpoort steken.
Voor gebruikers met moderne flat-laptops zullen deze waarschijnlijk een USB-to-Ethernet converter nodig hebben.

Iets wat hier zeker te vermelden valt is dat er nood zal zijn aan het correct labellen van alles.
Zowel op de patchpanelen als de kabels zou het geen slecht idee zijn om aan te geven waarmee je gaat verbinden.
Op de patchpanelen zal er vermeldt moeten worden boven welke poortnummers een verbinding geven met welk component van elk packet.
Bij de kabels zal er dan weer vermeld moeten worden welke een verbinding geeft naar het labonetwerk en welke naar het internet.  
https://www.allekabels.be/patchpaneel/6253/1198502/patchpaneel-24-poorts.html - patchpanelen  
https://www.codima.be/ - Kabels en connectoren

## Individuele componenten
We hebben ook rekening gehouden met de toekomst, indien er door slijtage of ongelukken componenten kapot zouden kunnen gaan.
Hiervoor hebben we 2 losse routers en switches besteld van hetzelfde type.
Om deze op te bergen, kunnen we eventueel gebruik maken van de carry cases die er nu liggen of misschien heeft de faculteit een betere locatie om deze op te slaan.

Verder bestellen we ook nog 1 extra switch om de last op de huidige inkomende switch te verlagen.
We steken daar nog één switch tussen, die op zich dan weer verbinding maakt met de 2 access points en de 2 klasnetwerken.
Dit zal de performantie te bate komen met dingen zoals broadcasts, pings en discovers.  
http://honim.typepad.com/files/netacad-promotion_ordering-guide_eligible_equipment_services-list.pdf - Cisco losse onderdelen

## Access points
Voor de access points is er gekoezen geweest voor TP Links TL-WA801nd.
Deze access points bieden een goede kwaliteit voor hun prijs, dat de reviews zeker bevestigen.
Buiten een makkelijke installatie biedt het ook PoE aan, heeft verschillende modussen en ondersteunt tot en met 4 VLAN's.
Zijn externe MIMO-antennes bieden een sterke verbinding aan.

Met als enigste nadeel dat het geen dual-band ondersteuning aanbiedt.  
 https://www.routercenter.be/product/483509/category-111443/tp-link-tl-wa801nd.html
