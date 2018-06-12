using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class MotivatieRepository : IMotivatieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Motivatie> _motivaties;

        public MotivatieRepository(ApplicationDbContext context)
        {
            _context = context;
            _motivaties = context.Motivaties;
        }
        public override List<Motivatie> GetAll()
        {
            return _motivaties.Include(m => m.Contactpersonen)
                .Include(m => m.Organisatie).ThenInclude(o => o.Locatie)
                .Include(m => m.Organisatie).ThenInclude(o => o.Contactpersonen).ToList();
        }

        public override void AddMotivatie(Motivatie motivatie)
        {
            _motivaties.Add(motivatie);
        }

        public override void UpdateMotivatie(Motivatie motivatie)
        {
            _motivaties.Update(motivatie);
        }

        public override void DeleteMotivatie(Motivatie motivatie)
        {
            _motivaties.Remove(motivatie);
        }

        public override void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
