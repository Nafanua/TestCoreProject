using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestApp.BusinessLogic.Models.Interfaces;
using TestApp.DataAccess.Models;
using AppContext = TestApp.DataAccess.AppContext;

namespace TestApp.BusinessLogic.Models
{
    public class SiteRepository : ISiteRepository
    {
        private readonly AppContext _context;

        public SiteRepository(string connectionString)
        {
            _context = new AppContext(connectionString);
        }

        public SiteDbo Add(SiteDbo entity)
        {
            _context.Sites.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<SiteDbo> GetAll()
        {
            return _context.Sites.AsEnumerable();
        }
    }
}
