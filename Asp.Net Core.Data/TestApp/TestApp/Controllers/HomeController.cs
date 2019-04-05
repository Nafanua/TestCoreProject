using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.BusinessLogic.Models;
using TestApp.BusinessLogic.Models.Interfaces;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteService _service;

        public HomeController(ISiteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await _service.GetTasksAsync();

            var model = new List<TaskViewModel>();

            var searchEngines = await _service.GetEnginesAsync();

            foreach (var task in tasks)
            {
                model.Add(new TaskViewModel
                {
                    SiteDomain = task.PostSite,
                    Keyword = task.PostKey,
                    Position = task.ResultPosition,
                    SearchEngineName = searchEngines.FirstOrDefault(i => i.Id == task.SearchEngineId)?.Name,
                    Status = task.ResultPosition.HasValue ? "processing" : "tracked "
                });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewTask()
        {
            var model = new AddNewTaskViewModel();

            var regions = await _service.GetLocationsAsync();
            var searchEngines = await _service.GetEnginesAsync();

            FillLists(model, searchEngines, regions);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTask(AddNewTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var r = await _service.SendTasksAsync(model.Priority, model.SiteDomain, model.SearchEngineId, model.LocationId,
                    model.Keywords);
                return RedirectToAction("Index");
            }

            var regions = await _service.GetLocationsAsync();
            var searchEngines = await _service.GetEnginesAsync();

            FillLists(model, searchEngines, regions);

            return View(model);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [NonAction]
        private void FillLists(AddNewTaskViewModel model, IList<SearchEngineModel> ses, IList<LocationModel> locs)
        {
            model.Regions.Add(new SelectListItem{Text = ""});
            model.SearchEngines.Add(new SelectListItem { Text = "" });
            model.Regions.AddRange(locs.Select(i => new SelectListItem
                { Value = i.Id.ToString(), Text = $"{i.Name}, {i.CountryIsoCode}" }).ToList());
            model.SearchEngines.AddRange(ses.Select(i => new SelectListItem
                    {Value = i.Id.ToString(), Text = $"{i.Name}, Language: {i.Language}"})
                .ToList());
        }
    }
}
