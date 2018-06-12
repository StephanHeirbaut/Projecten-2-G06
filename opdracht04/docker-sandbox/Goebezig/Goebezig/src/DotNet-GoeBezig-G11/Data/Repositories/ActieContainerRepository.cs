using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;

namespace DotNet_GoeBezig_G11.Data.Repositories
{
    public class ActieContainerRepository : IActieContainerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ActieContainer> _containers;
        public ActieContainerRepository(ApplicationDbContext context)
        {
            _context = context;
            _containers = _context.ActieContainers;
        }
        public void AddContainer(ActieContainer actieContainer)
        {
            _containers.Add(actieContainer);
        }

        public List<ActieContainer> GetAll()
        {
            return _containers.Include(a => a.Acties).ToList();
        }

        public void UpdateContainer(ActieContainer actieContainer)
        {
            _containers.Add(actieContainer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
