using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Xunit;

namespace test.Models
{
    public class CursistTest
    {
        private Locatie locatie;
        private School school;
        private string email;
        private Cursist cursist;

        public CursistTest()
        {
            locatie = new Locatie("a", 2, "Bel", 9000, "Gent");
            school = school = new School("Test", "hogeschool@hogent.be", locatie);
            email = "stevesinaeve@student.hogent.be";
            cursist = new Cursist("Jochem","Van Hespen","jochemvanhespen@student.hogent.be");
        }

        [Fact]
        public void NewCursist_ExtensieJuist()
        {
            //act
            Cursist cursist = new Cursist("Steve","Sinaeve",email);
        }
        [Fact]
        public void NewCursist_ExtensieFout()
        {
            //assert ;
            Cursist c = new Cursist("Steve", "Sinaeve", "qsdfmqklsdjf@hogen.be");
            Assert.Throws<ArgumentException>(() => c.School = school);
        }

        [Fact]
        public void NewCursistLegeVoornaam()
        {
            //assert
            Assert.Throws<ArgumentException>(() => new Cursist(string.Empty, "Van Hespen", email));
        }

        [Fact]
        public void NewCursistLegeNaam()
        {
            //assert
            Assert.Throws<ArgumentException>(() => new Cursist("Jochem", string.Empty, email));
        }

        [Fact]
        public void NewCursistLegeVoornaamNaam()
        {
            //assert
            Assert.Throws<ArgumentException>(() => new Cursist(string.Empty, string.Empty, email));
        }

        [Fact]
        public void NodigUitVoorGroep_CursistHeeftGroep_ArgumentException()
        {
            //arrange
            Groep groep = new Groep("Test",false);
            cursist.Groep = groep;

            //assert
            Assert.Throws<ArgumentException>(() => cursist.NodigUitVoorGroep("testgebruiker@hogent.be","TestGroep"));
        }

        [Fact]
        public void NodigUitVoorGroep_CursistParameterExtensieKomtNietOvereen_ArgumentException()
        {
            //assert
            Assert.Throws<ArgumentException>(() => cursist.NodigUitVoorGroep("testgebruiker@howest.be","TestGroep"));
        }

        [Fact]
        public void GetEmailExtensie_ExtensieKomtOvereen()
        {
            Assert.Equal("student.hogent.be", cursist.GetEmailExtensie());
        }

        [Fact]
        public void Constructor_ResultaatSchool()
        {
            Cursist cursist = new Cursist("Test","Test","testtest@test.be");
            Assert.Null(cursist.School);
        }
    }
}
