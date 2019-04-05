using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestApp.BusinessLogic.Models;
using TestApp.BusinessLogic.Models.Interfaces;
using TestApp.DataAccess.Models;

namespace TestApp.BusinessLogic.Services
{
    public class SiteService : ISiteService
    {
        private readonly ApiConnectionSettings _connectionSettings;

        private const string Country = "Zimbabwe";

        private readonly ISiteRepository _repository;

        private readonly IMapper _mapper;

        public SiteService(IOptions<ApiConnectionSettings> connectionSettings, ISiteRepository repository, IMapper mapper)
        {
            _connectionSettings = connectionSettings.Value;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SearchEngineModel>> GetEnginesAsync()
        {
            var httpClient = GetClient(true);

            var response = await httpClient.GetAsync("v2/cmn_se.gzip");

            var res = JsonConvert.DeserializeObject<ApiResponseModel<SearchEngineModel>>(await response.Content.ReadAsStringAsync());

            return res.Results.Where(i => i.CountryIsoCode == "NZ").ToList();
        }

        public async Task<List<LocationModel>> GetLocationsAsync()
        {
            var httpClient = GetClient(true);

            var response = await httpClient.GetAsync("v2/cmn_locations.gzip");

            var r = await response.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<ApiResponseModel<LocationModel>>(r);

            var country = res.Results.FirstOrDefault(i => i.Type == "Country" && i.CountryIsoCode == "NZ");

            return res.Results.Where(i => i.Type.Contains("Region") && i.ParentId == country?.Id).OrderBy(i => i.Name).ToList();
        }

        public async Task<bool> SendTasksAsync(int priority, string siteDomain, int seId, int locId, string keywords, string siteUrl = null)
        {
            var httpClient = GetClient(false);

            var postObject = new Dictionary<int, object>();

            var rnd = new Random(DateTime.Now.Millisecond);

            var splited = keywords.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < splited.Length; i++)
            {
                postObject.Add(
                    i,
                    new
                    {
                        priority = priority,
                        url = siteUrl,
                        site = siteDomain,
                        se_id = seId,
                        loc_id = locId,
                        key = splited[i]
                    });
            }

            var taskPostResponse = await httpClient.PostAsync("v2/rnk_tasks_post", new StringContent(JsonConvert.SerializeObject(new { data = postObject })));
            var response = JsonConvert.DeserializeObject<ApiResponseModel<TaskResponse>>(await taskPostResponse.Content.ReadAsStringAsync());
            if (response.Status != "error")
            {
                foreach (var task in response.Results)
                {
                    var dbObject = _mapper.Map<SiteDbo>(task);
                    _repository.Add(dbObject);
                }

                return true;
            }

            return false;
        }

        public async Task<List<STask>> GetTasksAsync()
        {
            var tasks = _repository.GetAll().ToList();

            var result = new List<STask>();

            var httpClient = GetClient(false);

            foreach (var task in tasks)
            {
                var response = await httpClient.GetAsync($"v2/rnk_tasks_get/{task.TaskId}");

                var str = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ApiTaskResponseModel>(str);

                if (obj.Status != "error" || obj.Results.Organic.Count > 0)
                {
                    result.Add(obj.Results.Organic.FirstOrDefault());
                }
            }

            return result;
        }

        private HttpClient GetClient(bool isCompressed)
        {
            HttpClient client;

            if (isCompressed)
            {
                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };

                client = new HttpClient(handler);
            }
            else
            {
                client = new HttpClient();
            }

            client.BaseAddress = new Uri(_connectionSettings.BaseUri);

            client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(
                $"{_connectionSettings.Login}:{_connectionSettings.Password}")));
                
            return client;
        }


    }
}
