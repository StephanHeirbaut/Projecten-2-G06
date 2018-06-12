using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class BerichtRepository : IBerichtRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Bericht> _berichten;

        public BerichtRepository(ApplicationDbContext context)
        {
            _context = context;
            _berichten = _context.Berichten;
        }

        public Bericht GetBy(int id)
        {
            var bericht = _berichten.Include(e=>e.Actie).FirstOrDefault(e=>e.Motivatie.MotivatieId==id);
            if (bericht == null)
            {
                throw new ArgumentException("Er zijn geen berichten beschikbaar");
            }
            return bericht;
        }

        public void AddBericht(Bericht bericht)
        {
            _berichten.Add(bericht);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Bericht> GetAll()
        {
            return _berichten.Include(e => e.Actie).ToList();
        }
    }
}
