# Opdracht 4: .Net deployment op Docker

## Opdrachtomschrijving

Het uitrollen van een .Net-applicatie op Windows Server is niet zo evident gebleken. Ondanks documentatie van Microsoft zelf, hebben de meeste teams hier mee geworsteld. Het doel van deze opdracht is om een alternatief uit te proberen voor het uitrollen van .Net-applicaties op serversystemen. Concreet is het de bedoeling om een proof-of-concept op te zetten van een .Net-applicatie die op Docker draait.

Docker is een virtualisatieplatform dat is gebaseerd op Linux Containers (LXC). een "container" is geen volwaardige virtuele machine, in die zin dat het besturingssysteem geen onderdeel is van de container. Met andere woorden, in de container zit enkel nog de applicatie en eventuele nodige programmabibliotheken en andere afhankelijkheden. Het gevolg is dat containers ook een stuk kleiner (en daardoor in theorie ook performanter) dan een klassieke virtuele machine.

Docker is op heel korte tijd sterk gegroeid als platform, in die mate dat ook Microsoft dit is gaan ondersteunen. Docker zal bijvoorbeeld standaard onderdeel worden van de volgende versie van Windows Server.

Bij containervirtualisatie is de best-practice om slechts één netwerkservice in een container te steken. Dat betekent dus ook dat voor een .Net-applicatie met een database backend (minstens) twee containers nodig zijn: één voor de database (SqlServer) en één voor de applicatie zelf. Microsoft heeft zelf container-images gepubliceerd waar je mee van start kan (zie verder) *en die werken op Linux!*

In eerste instantie kan je als demo-applicatie één gebruiken die gepubliceerd is door de lectoren van het programmeerproject, maar het is ook de bedoeling dat je probeert het project van één van de projectgroepen programmeren van dit academiejaar op te zetten in een Docker-omgeving.

- Proefopstelling Docker op Fedora 25: <https://github.com/bertvv/docker-sandbox>
- Demo-applicatie .Net: <https://github.com/WebIII/sol10MvcInDepth>
- Docker image Microsoft SQLServer: <https://hub.docker.com/r/microsoft/mssql-server-linux/>
- Docker images Microsoft ASP.NET: <https://hub.docker.com/r/microsoft/dotnet/>

## Verdere informatie

- Screencast "Introduction to Docker" <https://sysadmincasts.com/episodes/31-introduction-to-docker> (Merk op dat deze screencast vrij gedateerd is en misschien niet alles nog werkt zoals hier gedemonstreerd. Gebruik dit om wat inzicht te krijgen in wat Docker is en hoe het in grote lijnen werkt.)
- Get Started with Docker. <https://docs.docker.com/get-started/>
- Soper, N. (2016) *Hosting .Net Core on Linux with Docker - a noob's guide.* <http://blog.scottlogic.com/2016/09/05/hosting-netcore-on-linux-with-docker.html>
