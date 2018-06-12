using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class OrganisatieRepository : IOrganisatieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Organisatie> _organisaties;

        public OrganisatieRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _organisaties = _dbContext.Organisaties;
        }
        public Organisatie GetBy(string naam)
        {
            return _organisaties.Include(o => o.Contactpersonen).FirstOrDefault(o => o.Naam == naam);
        }

        public List<Organisatie> GetAll()
        {
            return _organisaties.Include(o => o.Contactpersonen).ToList();
        }


        public Contactpersoon GetContactpersonen(string naam, string email)
        {
            return GetBy(naam).Contactpersonen.Find(c => c.Email.Equals(email));
        }
    }
}
