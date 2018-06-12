using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class CursistRepository : ICursistRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Cursist> _cursists;

        public CursistRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _cursists = dbContext.Cursists;
        }
        public Cursist GetBy(string email)
        {
            //.Include(c => c.Begeleider)
            Cursist cursist = _cursists
                .Include(c => c.School)
                .Include(l => l.Lector)
                .Include(c => c.Groep).ThenInclude(g => g.Cursisten)
                .Include( c => c.Groep).ThenInclude( g => g.Motivaties).ThenInclude(m => m.Organisatie).ThenInclude(c => c.Contactpersonen)
                //.Include( c => c.Groep).ThenInclude( g => g.Motivaties).ThenInclude(m => m.Organisatie).ThenInclude(o => o.Locatie)
                .Include(c => c.Groep).ThenInclude(g => g.Motivaties).ThenInclude(m => m.Contactpersonen)
                .Include(c => c.Groep).ThenInclude(g => g.CurrentState)
                .Include( c => c.Groep).ThenInclude( g => g.ActieContainers).ThenInclude( a => a.Acties).ThenInclude(t => t.Taken)
                .Include(c => c.Meldingen).SingleOrDefault(c => c.Email == email);
            if (cursist == null)
            {
                throw new Exception($"Er bestaat geen Cursist met E-mail {email}");
            }
            return cursist;
        }

        public IEnumerable<Cursist> GetAll()
        {
            //.Include(c => c.Begeleider)
            return _cursists.Include(c => c.School)
                .Include(c => c.Groep).ThenInclude(g => g.Cursisten)
                .Include(c => c.Meldingen).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void AddCursist(Cursist cursist)
        {
            _cursists.Add(cursist);
        }

        public void UpdateCursist(Cursist cursist)
        {
            _cursists.Update(cursist);
        }

        public IList<Cursist> GeefUitgenodigden(Cursist cursist)
        {
            List<Cursist> viewbagLijst = new List<Cursist>();

            foreach (Cursist c in GetAll())
            {
                foreach (Melding melding in c.Meldingen)
                {
                    if (melding.GroepNaam != null)
                    {
                        if (melding.GroepNaam.Equals(cursist.Groep.Naam) &&
                            melding.Inhoud.Contains("U bent uitgenodigd voor een groep"))
                        {
                            viewbagLijst.Add(c);
                        }
                    }

                }
            }
            return viewbagLijst;
        }
    }
}
