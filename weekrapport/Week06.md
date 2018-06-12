# Voortgangsrapport week 06

* Groep: G06
* Datum: 13/03/2017 - 19/03/2017

| Student  | Aanw. | Opmerking |
| :---     | :---  | :---      |
| Quinten De Bruyne  |   Ja    |           |
| Bert Provoost |    Ja   |           |
| Jodie De Pestel |     Ja  |           |
| Stephan Heirbaut  |     Ja  |           |

## Wat heb je deze week gerealiseerd?

### Algemeen

[Afbeelding huidige toestand Kanban-bord(en) invoegen]

* ![kanbanweek06](https://cloud.githubusercontent.com/assets/17174539/24089510/c03c7fba-0d37-11e7-98eb-41ebd34672c9.png)

[Afbeelding teamoverzicht tijdregistratie onderverdeeld per deelopdracht]

### Quinten De Bruyne

* ![naamloos](https://cloud.githubusercontent.com/assets/17174552/24091500/bc625eb2-0d48-11e7-93f9-94805831f8a5.png)

### Bert Provoost

* ![toggl week6](https://cloud.githubusercontent.com/assets/17174277/24091487/a5f31040-0d48-11e7-989a-727ab64eccb8.png)

[Afbeelding individueel rapport tijdregistratie]

### Jodie De Pestel

![jodie_toggl](https://cloud.githubusercontent.com/assets/17159222/24083132/e38aefee-0cd1-11e7-9e3d-4a8412e2b73f.png)

[Afbeelding individueel rapport tijdregistratie]

### Stephan Heirbaut

* ![week06](https://cloud.githubusercontent.com/assets/17174539/24089511/c20e38a6-0d37-11e7-862b-0552a0e21ee4.png)

## Wat plan je volgende week te doen?

### Algemeen
Labo 2 volledig afgewerkt
Labo 3
### Quinten De Bruyne 
Labo 2 - Opdracht 2 - WISAstack & Applicatie Asp.net 
Labo 3 - grondplan
### Bert Provoost
Labo 2 Opdracht 1&3 - LAMP & JAVAEEstack
Labo 3 - grondplan
### Jodie De Pestel
Labo 2 - Opdracht 2 - WISAstack  
Labo 2 - Opdracht 4 - Cloudservices 
Labo 3 - grondplan
### Stephan Heirbaut
Labo 2 - Opdracht 1&3 - LAMP & JAVAEEstack  
Labo 3 - grondplan

## Waar hebben jullie nog problemen mee?

* Maven en WAR-file
* WISA-applicatie
* Grondplan

## Feedback technisch luik

### Algemeen

- Geen nieuwe taken klaar voor evaluatie
- Opdracht webapplicatieplatformen: JavaEE
    - Zorg dat juiste packages geïnstalleerd zijn! Bv. `javac` zit niet in `openjdk` package, wel in `openjdk-devel`
    - Tip: `yum provides *bin/COMMANDO` geeft een lijst met packages waar `COMMANDO` in zit
    - Voer mysql queries in provisioning-script enkel uit als het root-wachtwoord nog niet ingesteld was. Ik test dit met het commando `mysqladmin --user=root status`. Als de exit-status van dit commando 0 is, is het wachtwoord nog *niet* ingesteld.
    - Fout bij opstarten Tomcat wordt veroorzaakt door hard-coded waarden voor database in `JAVAEEapplicatie/src/main/java/config/PersistenceJPAConfig.java`. Zet een database op voor de webapplicatie en pas de Java-code aan zodat die consistent is.
    - Zie evt. <https://github.com/HoGentTIN/javaee-poc> voor een proof-of-concept
    - Als er iets niet werkt dat service-gerelateerd is, dan zijn er normaal log-files te vinden in `/var/log`, in dit geval `/var/log/tomcat`
- Opdracht webapplicatieplatformen: WISA-applicatie
    - Lukt niet in Core => opnieuw uitproberen met GUI-versie

## Feedback analyseluik

### Algemeen

### Quinten De Bruyne 
### Bert Provoost
### Jodie De Pestel
### Stephan Heirbaut

