using AutoMapper;
using TestApp.BusinessLogic.Models;
using TestApp.DataAccess.Models;

namespace TestApp.BusinessLogic.Util
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SiteDbo, TaskResponse>();
            CreateMap<TaskResponse, SiteDbo>();
        }
    }
}
