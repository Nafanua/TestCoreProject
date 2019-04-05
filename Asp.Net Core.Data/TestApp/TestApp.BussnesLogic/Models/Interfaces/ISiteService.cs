using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApp.BusinessLogic.Models.Interfaces
{
    public interface ISiteService
    {
        Task<List<SearchEngineModel>> GetEnginesAsync();

        Task<List<LocationModel>> GetLocationsAsync();

        Task<bool> SendTasksAsync(int priority, string siteDomain, int seId, int locId, string keywords,
            string siteUrl = null);

        Task<List<STask>> GetTasksAsync();
    }
}
