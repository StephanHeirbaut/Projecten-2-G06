# Voortgangsrapport week 07

* Groep: G06
* Datum: 20/03/2017 - 26/03/2017

| Student  | Aanw. | Opmerking |
| :---     | :---  | :---      |
| Quinten De Bruyne  |  Nee     | Ongewettigd afwezig  |
| Bert Provoost |    Ja   |           |
| Jodie De Pestel |    Nee   | Gewettigd afwezig |
| Stephan Heirbaut  |   Ja    |           |

## Wat heb je deze week gerealiseerd?

### Algemeen

[Afbeelding huidige toestand Kanban-bord(en) invoegen]

*  ![kanbanbord week7](https://cloud.githubusercontent.com/assets/17174277/24348003/7ca67c94-12da-11e7-89f2-dd55b3bddcf4.png)

[Afbeelding teamoverzicht tijdregistratie onderverdeeld per deelopdracht]

### Quinten De Bruyne

* ![naamloos](https://cloud.githubusercontent.com/assets/17174552/24496502/b4db47f6-1538-11e7-98e6-d70a44f43fe9.png)



### Bert Provoost

* ![toggle week7](https://cloud.githubusercontent.com/assets/17174277/24343492/0a02f0ea-12c7-11e7-9506-a90077941764.png)


[Afbeelding individueel rapport tijdregistratie]

### Jodie De Pestel

* ![jodietoggle](https://cloud.githubusercontent.com/assets/17174539/24335148/17e28b20-1278-11e7-92a1-dd24c4302046.png)

### Stephan Heirbaut

* ![week07](https://cloud.githubusercontent.com/assets/17174539/24335075/fcfd8f0e-1276-11e7-95ae-47625cf45d5a.png)

## Wat plan je volgende week te doen?

### Algemeen
Opdracht 2 afwerken
Opdracht 3 op weg
### Quinten De Bruyne 
Opdracht 2 - WISAstack afwerken
### Bert Provoost
Opdracht 2 - LAMP- & JAVAEEstack afwerken
### Jodie De Pestel
Opdracht 2 - WISAstack afwerken
### Stephan Heirbaut
Opdracht 2 - LAMP- & JAVAEEstack afwerken

## Waar hebben jullie nog problemen mee?

* Virtual Box Guest Additions
* Verdere automatisatie nodig?

## Feedback technisch luik

### Algemeen

- VirtualBox Guest Additions-probleem: `vagrant-vbguest` plugin mag niet geïnstalleerd zijn (base box is niet compatibel, zie <https://atlas.hashicorp.com/bertvv/boxes/centos72>)
- Opdracht 2, JavaEE
    - Maak scripts configureerbaar door veranderlijke waarden (app db naam, gebruiker, wachtwoord, ...) in variabelen te steken. Nu zijn die hard-coded
    - Geholpen met debuggen, tot werkend PoC gekomen
    - Maak scripts herbruikbaar door configureeerbare zaken (db naam, gebruiker, wachtwoord) in variabelen te steken
    - Gelijkaardige opm. voor LAMP-script
- Opdracht 3:
    - Logisch plan uitgewerkt, besproken
    - Vaste racks in de hoeken van de 2 lokalen

Tip: instellen Mariadb root-wachtwoord als het nog niet gebeurd is:

```Bash
if mysqladmin -u root status > /dev/null 2>&1; then
  # if the previous command succeeds, the root password was not set
  mysqladmin password "${mariadb_root_password}" > /dev/null 2>&1
  info "ok"
else
  info "password already set."
fi
```

### Quinten De Bruyne 

- Ongewettigd afwezig, je komt in de gevarenzone voor slagen
- Ik verwacht tegen volgende samenkomst een concrete vooruitgang in de WISA-opdracht. Je toont dit aan aan de hand van Git commits van de scripts + documentatie die je geschreven hebt. Als je vast zit, contacteer me VOOR het volgende opvolgingsgesprek.

## Feedback analyseluik

### Algemeen

### Quinten De Bruyne 
### Bert Provoost
### Jodie De Pestel
### Stephan Heirbaut
