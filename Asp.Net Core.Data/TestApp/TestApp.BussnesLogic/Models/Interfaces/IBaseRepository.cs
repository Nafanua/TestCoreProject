using System.Collections.Generic;
using TestApp.DataAccess.Models;

namespace TestApp.BusinessLogic.Models.Interfaces
{
    public interface ISiteRepository
    {
        SiteDbo Add(SiteDbo entity);
        IEnumerable<SiteDbo> GetAll();
    }
}
