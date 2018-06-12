using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class ActieRepository : IActieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Actie> _acties;
        public ActieRepository(ApplicationDbContext context)
        {
            _context = context;
            _acties = _context.Acties;
        }

        public void AddActie(Actie actie)
        {
            _acties.Add(actie);
        }

        public void UpdateActie(Actie actie)
        {
            _acties.Update(actie);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteActie(Actie actie)
        {
            _acties.Remove(actie);
        }

        public List<Actie> GeeActies()
        {
            return _acties.Include(a=>a.Bericht).Where(a => a.Datum == null).ToList();
        }

        public List<Actie> GeefEvenementen()
        {
            return _acties.Include(a=>a.Bericht).Where(a => a.Datum != null).ToList();
        }

        public List<Actie> GeefAlles()
        {
            return _acties.Include(a => a.Taken).ToList();
        }

        public Actie GetById(int id)
        {
            return _acties.Include(a => a.Taken).SingleOrDefault(a => a.ActieId == id);
        }

        public Actie GeefActie(int i)
        {
            return _acties.FirstOrDefault(e => e.ActieId == i);
        }

        public void VerwijderActie(Actie actie)
        {
            _acties.Remove(actie);
        }
    }
}
