# Algemene inventaris
## Inventaris van de netwerkapparatuur in B4.037/38

- 40 vaste computers
- 30 switchen met verschillend aantal poorten.
- 10 routers
- 8 dozen waar telkens drie switchen in passen.

## Afmetingen lokalen
Van tot de eerste bank = 2m  
Van het begin van de ene bank tot het begin van de volgende bank = 2m  
Tafel lengte = 1.5m  
Breedte lokaal (van raam naar deur) = 10.5m  
Van bord tot scheidingswand = 10m  
Hoogte lokaal = 4m  

## Aantal benodige connectoren
# stephan zen idee:  
40 PC's per lokaal = 80 connectoren  
6 connectoren per component, 3 componenten per packet, 8 packets = 144 connectoren  
2 access points = 4 connectoren  
1 switch met een verbindingen naar 2 andere switches = 4 connectoren  

# bert zen idee:  
40 pc's in totaal: 1 connector aan pc kant, geen aan patchpaneel kant. (btw: mss hierbij vermelden dat het solid kabels zijn)  
achteraan worden de kabels vastgemaakt in het paneel zonder connector (zie: https://www.youtube.com/watch?v=lg2oGE02DJE&t=70s )   
als we kijken naar het grootste labe (labo 4 van opdracht01) dan hebben we verbinding nodig tussen pc, paneel, switch en router.  
dus van patchpaneel naar switch: 2connectoren  
van switch naar router: 2connectoren  
van router naar router: 2connectoren  
we hebben nooit tussen alle routers een kabel nodig dus hebben we nog kabels op overschot (btw: mss hierbij vermelden dat het stranded kabels zijn)  
dat is in totaal 1 + 2 + 2 +2 = 7 en dat voor 40 pc's => 40 * 7 = 280  
2 access points = 4 connectoren  
1 switch met een verbindingen naar 2 andere switches = 6 connectoren (je kabel die uit de muur komt naar je eerste swith en dan nog 2 kabels naar de 2 andere switchen)  
in totaal dus 288 connectoren.

