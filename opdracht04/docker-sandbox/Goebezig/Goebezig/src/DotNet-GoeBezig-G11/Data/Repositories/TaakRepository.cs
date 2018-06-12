using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class TaakRepository : ITaakRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Taak> taken;

        public TaakRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            taken = _dbContext.Taken;
        }
        public Taak GetBy(int id)
        {
            return taken.FirstOrDefault(t => t.TaakId == id);
        }

        public List<Taak> GetAll()
        {
            return taken.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(Taak taak)
        {
            taken.Remove(taak);
        }
    }
}
