using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<School> _schools;

        public SchoolRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _schools = dbContext.Schools;
        }
        public School GetBy(string naam)
        {
            return _schools.Include(s => s.Locatie).Include(o => o.Contactpersonen).SingleOrDefault(s => s.Naam == naam);
        }

        public List<School> GetAll()
        {
            return _schools.Include(s => s.Locatie).ToList();
        }
    }
}
