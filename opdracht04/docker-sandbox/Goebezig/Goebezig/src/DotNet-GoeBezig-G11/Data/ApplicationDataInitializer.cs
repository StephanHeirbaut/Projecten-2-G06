//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DotNet_GoeBezig_G11.Models;
//using DotNet_GoeBezig_G11.Models.Domein;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;

//namespace DotNet_GoeBezig_G11.Data
//{
//    public class ApplicationDataInitializer
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly ApplicationDbContext _dbContext;
//        private readonly ISchoolRepository _schoolRepository;

//        public ApplicationDataInitializer(UserManager<ApplicationUser> userManager, ISchoolRepository schoolRepository, ApplicationDbContext dbContext)
//        {
//            _userManager = userManager;
//            _schoolRepository = schoolRepository;
//            _dbContext = dbContext;
//        }
//        public async Task InitializeData()
//        {

//            //Locatie locatie = new Locatie("Plateau", 40, "België", 9000, "Gent");
//            //Locatie locatie1 = new Locatie("Voskenslaan", 91, "België", 9000, "Gent");
//            //Locatie locatie2 = new Locatie("AugustijnenStraat", 12, "België", 8900, "Ieper");
//            //Locatie locatie3 = new Locatie("Roosbruggedamestraat", 18, "België", 8900, "Ieper");

//            //School school = new School("Universiteit Gent", "Ugent@ugent.be", locatie);
//            //School school1 = new School("Hogeschool Gent", "hogent@hogent.be", locatie1);
//            //School school2 = new School("VTI Ieper", "VTI@VTIieper.be", locatie2);
//            //School school3 = new School("Lyceum", "ieper@Lyceum.be", locatie3);

//            //School[] scholen = new School[] { school, school1, school2, school3 };
//            //_dbContext.Schools.AddRange(scholen);
//            //await InitializeUsers();

//            //var cursist1 = new Cursist("Barry", "Badpak", "testgebruiker@hogent.be");
//            //cursist1.Meldingen.Add(new Melding("Dit is een test melding"));
//            //Lector lector1 = new Lector("Flip", "Flop", "flip@hogent.be");
//            ////var cursist = new Cursist("Barry", "Badpak", "testgebruiker@hogent.be");
//            var cursist = new Cursist("Fulvio", "Gentile", "gebr1@hogent.be");
//            cursist.Meldingen.Add(new Melding("Dit is een test melding"));
//            //Lector lector = new Lector("Irina", "Malfait", "Irina.Malfait@hogent.be");
//            //cursist.Lector = lector;
//            //_dbContext.Lectors.Add(lector);
//            _dbContext.Cursists.Add(cursist);

//            //Contactpersonen toevoegen

//            #region Contactpersonen toevoegen
//            var telnr1 = "051246575";
//            var telnr2 = "051259856";
//            var telnr3 = "050287456";
//            var telnr4 = "0489529851";
//            var telnr5 = "0487562019";

//            var vnaam1 = "Boris";
//            var vnaam2 = "Joris";
//            var vnaam3 = "Kolya";
//            var vnaam4 = "Peter";
//            var vnaam5 = "Merel";

//            var naam1 = "Van Der Hoeven";
//            var naam2 = "De Bakker";
//            var naam3 = "Rotsteijn";
//            var naam4 = "De Jaeger";
//            var naam5 = "De meester";

//            var functie1 = "CEO";
//            var functie2 = "Woordvoerder";

//            var aanspreektitel1 = "Meneer";
//            var aanspreektitel2 = "Mevrouw";
//            var email1 = "boris.vanderhoeven@gmail.com";
//            var email2 = "joris.debakker@gmail.com";
//            var email3 = "kolya_rotsteijn@hotmail.com";
//            var email4 = "peterdejaeger@hotmail.com";
//            var email5 = "merel.demeester@gmail.com";
//            //contactpersoon(naam,voornaam,email,tel,aanspr,functie);
//            var contactpersoon1 = new Contactpersoon(naam1,vnaam1,email1,aanspreektitel1,telnr1,functie2);
//            var contactpersoon2 = new Contactpersoon(naam2, vnaam2, email2, aanspreektitel1, telnr2, functie2);
//            var contactpersoon3 = new Contactpersoon(naam3,vnaam3,email3,aanspreektitel1,telnr3,functie2);
//            var contactpersoon4 = new Contactpersoon(naam4,vnaam4,email4,aanspreektitel1,telnr4,functie1);
//            var contactpersoon5 = new Contactpersoon(naam5, vnaam5, email5, aanspreektitel2,telnr5,functie2);
//            #endregion
            
//            _dbContext.Add(contactpersoon1);
//            _dbContext.Add(contactpersoon2);
//            _dbContext.Add(contactpersoon3);
//            _dbContext.Add(contactpersoon4);
//            _dbContext.Add(contactpersoon5);

//            //Organisaties toevoegen
//            #region Organisaties toevoegen



//            #endregion


//            await _dbContext.SaveChangesAsync();
//        }

//        private async Task InitializeUsers()
//        {
//            //var user1 = new ApplicationUser();
//            //user1.Email = "testgebruiker@hogent.be"; 
//            //user1.UserName = "testgebruiker@hogent.be";
//            //await _userManager.CreateAsync(user1, "Abc_123");


//            var user = new ApplicationUser();
//            user.Email = "gebruiker@hogent.be";
//            user.UserName = "gebruiker@hogent.be";
//            await _userManager.CreateAsync(user, "Abc_123");


//        }
//    }

//}
//appdbcontext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNet_GoeBezig_G11.Data
{
    public class ApplicationDataInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ISchoolRepository _schoolRepository;

        public ApplicationDataInitializer(UserManager<ApplicationUser> userManager, ISchoolRepository schoolRepository, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _schoolRepository = schoolRepository;
            _dbContext = dbContext;
        }
        public async Task InitializeData()
        {

            Locatie locatie = new Locatie("Plateau", 40, "België", 9000, "Gent");
            Locatie locatie1 = new Locatie("Voskenslaan", 91, "België", 9000, "Gent");
            Locatie locatie2 = new Locatie("AugustijnenStraat", 12, "België", 8900, "Ieper");
            Locatie locatie3 = new Locatie("Roosbruggedamestraat", 18, "België", 8900, "Ieper");

            School school = new School("Universiteit Gent", "Ugent@ugent.be", locatie);
            School school1 = new School("Hogeschool Gent", "hogent@hogent.be", locatie1);
            School school2 = new School("VTI Ieper", "VTI@VTIieper.be", locatie2);
            School school3 = new School("Lyceum", "ieper@Lyceum.be", locatie3);

            School[] scholen = new School[] { school, school1, school2, school3 };

            _dbContext.Schools.AddRange(scholen);


            var cursist1 = new Cursist("Barry", "Badpak", "testgebruiker@hogent.be");
            cursist1.Meldingen.Add(new Melding("Dit is een test melding"));
            Lector lector1 = new Lector("Flip", "Flop", "flip@hogent.be");
            var cursist = new Cursist("Barry", "Badpak", "testgebruiker@hogent.be");
            var cursist2 = new Cursist("Steve", "Sinaeve", "gebruiker@hogent.be");
            cursist.Meldingen.Add(new Melding("Dit is een test melding"));
            Lector lector = new Lector("Irina", "Malfait", "Irina.Malfait@hogent.be");
            cursist.Lector = lector;
            _dbContext.Lectors.Add(lector);
            _dbContext.Cursists.Add(cursist);
            _dbContext.Cursists.Add(cursist2);

            //Contactpersonen toevoegen

            #region Contactpersonen toevoegen
            var telnr1 = "051246575";
            var telnr2 = "051259856";
            var telnr3 = "050287456";
            var telnr4 = "0489529851";
            var telnr5 = "0487562019";

            var vnaam1 = "Boris";
            var vnaam2 = "Joris";
            var vnaam3 = "Kolya";
            var vnaam4 = "Peter";
            var vnaam5 = "Merel";

            var naam1 = "Van Der Hoeven";
            var naam2 = "De Bakker";
            var naam3 = "Rotsteijn";
            var naam4 = "De Jaeger";
            var naam5 = "De meester";

            var functie1 = "CEO";
            var functie2 = "Woordvoerder";

            var aanspreektitel1 = "Meneer";
            var aanspreektitel2 = "Mevrouw";
            var email1 = "boris.vanderhoeven@cm.be";
            var email2 = "joris.debakker@gmail.com";
            var email3 = "kolya_rotsteijn@hotmail.com";
            var email4 = "peterdejaeger@hotmail.com";
            var email5 = "merel.demeester@gmail.com";



            #endregion

            //Organisaties toevoegen
            #region Organisaties       
            Locatie locatie4 = new Locatie("Kortrijksesteenweg", 18, "België", 9000, "Gent");
            string type1 = "feitelijke vereniging";
            string type2 = "vzw";
            string type3 = "CVBA";
            string type4 = "ziekenfonds";
            string type5 = "instelling van openbaar nut";
            string type6 = "school";

            Organisatie org1 = new Organisatie("Christelijke mutualiteit2", "info@cm.be", locatie4, type4);



            Locatie locatie5 = new Locatie("Poortstraat", 52, "België", 8820, "Torhout");

            Organisatie org2 = new Organisatie("SK Torhout", "info@sk.be", locatie5, type2);

            Organisatie org3 = new Organisatie("Boterbloemscouts", "scouts@boterbloempjes.be", locatie4, type2);

            Organisatie org4 = new Organisatie("Rainbow Belgium", "info@rainbow.be", locatie, type3);


            Organisatie org5 = new Organisatie("NMBS", "treinen_enzo@nmbs.be", locatie, type5);

            Locatie locatie6 = new Locatie("Stationstraat", 22, "België", 1500, "Halle");
            Organisatie org6 = new Organisatie("Colruyt", "info.colruyt@colruytgroup.be", locatie6, type1);



            Organisatie org7 = new Organisatie("KTA Torhout", "info@kta.torhout.be", locatie5, type6);


            Organisatie org8 = new Organisatie("VTI Torhout", "info@vti.be", locatie5, type6);


            Organisatie org9 = new Organisatie("Lyceum Gent", "info@lyceumgent.be", locatie, type6);


            Locatie locatie7 = new Locatie("Jozef II straat", 40, "België", 1000, "Brussel");
            Organisatie org10 = new Organisatie("Bureau voor Normalisatie", "info@bvn.be", locatie7, type5);


            Organisatie org11 = new Organisatie("Nationaal Pensioenfonds voor mijnwerkers", "info@npvm.be", locatie7, type5);


            Organisatie org12 = new Organisatie("Instituut voor de gelijkheid van vrouwen en mannen", "info@gelijkheid.be", locatie7, type5);


            Organisatie org13 = new Organisatie("Moestuin roes", "info@moestuin.be", locatie, type1);


            Organisatie org14 = new Organisatie("Boekenclub de worm", "info@feitelijkeorg.be", locatie, type1);

            Organisatie org15 = new Organisatie("Boterkoeken voor blokkers", "info@feitelijkeorg.be", locatie, type1);


            Organisatie org16 = new Organisatie("Loopgroep voor mindervaliden", "info@feitelijkeorg.be", locatie, type1);


            Organisatie org17 = new Organisatie("WoninGent", "info@cvba.be", locatie, type3);

            Organisatie org18 = new Organisatie("WoonWel", "info@cvba.be", locatie5, type3);


            Organisatie org19 = new Organisatie("CVBA ABC", "info@cvba.be", locatie1, type3);

            Organisatie org20 = new Organisatie("EnerGent", "info@cvba.be", locatie1, type3);


            Organisatie org21 = new Organisatie("Partago", "info@cvba.be", locatie1, type3);


            Organisatie org22 = new Organisatie("Hogeschool Vives", "onthaal@vives.be", locatie1, type6);


            Locatie locatie8 = new Locatie("Boomstraat", 6, "België", 3000, "leuven");
            Organisatie org23 = new Organisatie("KU Leuven", "onthaal@kuleuven.be", locatie8, type6);


            Organisatie org24 = new Organisatie("Arteveldehogeschool", "contact@arteveldehogeschool.be", locatie, type6);


            Organisatie org25 = new Organisatie("Neutraal Ziekenfonds", "info@neutraalziekenfonds.be", locatie3, type4);

            Organisatie org26 = new Organisatie("Bond Moyson", "info@bondmoyson.be", locatie, type4);
            #endregion

            Organisatie[] organisaties = new Organisatie[] { org1, org2, org3, org4, org5, org6, org7, org8, org9, org10, org11, org12, org13, org14, org15, org16, org17, org18, org19, org20, org21, org22, org23, org24, org25, org26 };


            _dbContext.Organisaties.Add(org1);
            //contactpersoon(naam, voornaam, email, tel, aanspr, functie);
            Contactpersoon contactpersoon = new Contactpersoon(naam2, vnaam2, email2, aanspreektitel1, telnr2, functie2, org1);
            Contactpersoon contactpersoon1 = new Contactpersoon(naam1, vnaam1, email1, aanspreektitel1, telnr1, functie2, org2);
            Contactpersoon contactpersoon2 = new Contactpersoon(naam2, vnaam2, email2, aanspreektitel1, telnr2, functie2, org3);
            Contactpersoon contactpersoon3 = new Contactpersoon(naam3, vnaam3, email3, aanspreektitel1, telnr3, functie2, org4);
            Contactpersoon contactpersoon4 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org5);

            Contactpersoon contactpersoon5 = new Contactpersoon(naam5, vnaam5, email5, aanspreektitel2, telnr5, functie2, org6);

            Contactpersoon contactpersoon6 = new Contactpersoon(naam3, vnaam3, email3, aanspreektitel1, telnr3, functie2, org7);
            Contactpersoon contactpersoon7 = new Contactpersoon(naam1, vnaam1, email1, aanspreektitel1, telnr1, functie2, org8);

            Contactpersoon contactpersoon8 = new Contactpersoon(naam5, vnaam5, email5, aanspreektitel2, telnr5, functie2, org9);

            Contactpersoon contactpersoon9 = new Contactpersoon(naam3, vnaam3, email3, aanspreektitel1, telnr3, functie2, org10);

            Contactpersoon contactpersoon10 = new Contactpersoon(naam5, vnaam5, email5, aanspreektitel2, telnr5, functie2, org11);

            Contactpersoon contactpersoon11 = new Contactpersoon(naam2, vnaam2, email2, aanspreektitel1, telnr2, functie2, org12);
            Contactpersoon contactpersoon12 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org13);
            Contactpersoon contactpersoon13 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org14);
            Contactpersoon contactpersoon14 = new Contactpersoon(naam1, vnaam1, email1, aanspreektitel1, telnr1, functie2, org15);
            Contactpersoon contactpersoon15 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org16);
            Contactpersoon contactpersoon16 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org17);
            Contactpersoon contactpersoon17 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org18);
            Contactpersoon contactpersoon18 = new Contactpersoon(naam1, vnaam1, email1, aanspreektitel1, telnr1, functie2, org19);
            Contactpersoon contactpersoon19 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org20);
            Contactpersoon contactpersoon20 = new Contactpersoon(naam3, vnaam3, email3, aanspreektitel1, telnr3, functie2, org21);
            Contactpersoon contactpersoon21 = new Contactpersoon(naam4, vnaam4, email4, aanspreektitel1, telnr4, functie1, org22);
            Contactpersoon contactpersoon22 = new Contactpersoon(naam1, vnaam1, email1, aanspreektitel1, telnr1, functie2, org23);
            Contactpersoon contactpersoon23 = new Contactpersoon(naam2, vnaam2, email2, aanspreektitel1, telnr2, functie2, org24);
            Contactpersoon contactpersoon24 = new Contactpersoon(naam1, vnaam1, email1, aanspreektitel1, telnr1, functie2, org25);
            Contactpersoon contactpersoon25 = new Contactpersoon(naam3, vnaam3, email3, aanspreektitel1, telnr3, functie2, org26);



            List<Contactpersoon> contactpersoons = new List<Contactpersoon>();
            contactpersoons.Add(contactpersoon);
            contactpersoons.Add(contactpersoon1);
            contactpersoons.Add(contactpersoon2);
            contactpersoons.Add(contactpersoon3);
            contactpersoons.Add(contactpersoon4);
            contactpersoons.Add(contactpersoon5);
            contactpersoons.Add(contactpersoon6);
            contactpersoons.Add(contactpersoon7);
            contactpersoons.Add(contactpersoon8);
            contactpersoons.Add(contactpersoon9);
            contactpersoons.Add(contactpersoon10);
            _dbContext.AddRange(contactpersoons);

            var gebr1 = new Cursist("Fulvio", "Gentile", "gebr1@hogent.be");
            var gebr2 = new Cursist("Jochem", "Van Hespen", "gebr2@hogent.be");
            _dbContext.Cursists.Add(gebr1);
            var gebr = new Cursist("Gammoudi", "Robin", "gebruiker3@hogent.be");
            gebr.Lector = lector;
           
            var actie = new Actie("testActie","shit doen");
            actie.MaakBericht(actie,"aankodiging");
            _dbContext.Acties.Add(actie);
            
            _dbContext.Cursists.Add(gebr);
            _dbContext.Cursists.Add(gebr2);
           // var motivatieInh ="Wij hebben deze jeudgwerking gekozen omdat de jeudgtrainers zich elke dag inzetten voor hun spelertjes.Ze streven om een familiale sportclub te zijn waar hun spelers zich thuis voelen en uitgedaagd worden om op een faire manier voetbal te spelen én zich in deze sport steeds verder te ontwikkelen. Ze dragen RESPECT hoog in het vaandel, en dit niet alleen tegenover elkaar, de tegenstrever en alle betrokken partijen (scheidsrechter, begeleiders, ouders,…), maar ook voor het materiaal en de infrastructuur. Door hun inzet en missie vinden wij dat ze goed bezig zijn. Daarom hebben we deze organisatie gekozen om aan hen het goed bezig label te schenken.";

            //var groep = new Groep("Groep van Robin", true);
            //gebr.Groep = groep;
            //var motivatie = new Motivatie(motivatieInh, org2);
            //gebr.DienMotivatieIn(motivatie);
           // Actie actie = new Actie("ayy","lemai");
            //actie.MaakBericht(actie);

            await InitializeUsers();
            await _dbContext.SaveChangesAsync();
        }

        private async Task InitializeUsers()
        {
            var user1 = new ApplicationUser();
            user1.Email = "testgebruiker@hogent.be";
            user1.UserName = "testgebruiker@hogent.be";
            await _userManager.CreateAsync(user1, "Abc_123");


            var user = new ApplicationUser();
            user.Email = "gebruiker@hogent.be";
            user.UserName = "gebruiker@hogent.be";
            await _userManager.CreateAsync(user, "Abc_123");


            var user2 = new ApplicationUser();
            user2.Email = "gebr1@hogent.be";
            user2.UserName = "gebr1@hogent.be";
            await _userManager.CreateAsync(user2, "Abc_123");

            var user3 = new ApplicationUser();
            user3.Email = "gebr2@hogent.be";
            user3.UserName = "gebr2@hogent.be";
            await _userManager.CreateAsync(user3, "Abc_123");

            var user4 = new ApplicationUser();
            user4.Email = "gebruiker3@hogent.be";
            user4.UserName = "gebruiker3@hogent.be";
            await _userManager.CreateAsync(user4, "Abc_123");

        }


    }

}
