using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class GroepRepository : IGroepRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Groep> _groeps;

        public GroepRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _groeps = _dbContext.Groeps;
        }

        public IEnumerable<Groep> GetAll()
        {
            return _groeps.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void AddGroep(Groep groep)
        {
            _groeps.Add(groep);
        }

        public Groep GetBy(string naam)
        {
            Groep groep =
                _groeps.Include(g => g.CurrentState)
                    .Include(g => g.Cursisten).ThenInclude(c => c.Meldingen)
                    .Include(g => g.Motivaties)
                    .SingleOrDefault(c => c.Naam == naam);
            //if (groep == null)
            //{
            //    throw new Exception($"Er bestaat geen groep met naam {naam}");
            //}
            return groep;
        }

        public void UpdateGroep(Groep groep)
        {
            _groeps.Update(groep);
        }
    }
}
