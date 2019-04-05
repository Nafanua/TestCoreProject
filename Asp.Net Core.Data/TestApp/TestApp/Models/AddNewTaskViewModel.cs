using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestApp.Models
{
    public class AddNewTaskViewModel
    {
        public List<SelectListItem> SearchEngines { get; set; }
        public List<SelectListItem> Regions { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DisplayName("Priority*:")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DisplayName("Site Domain*:")]
        public string SiteDomain { get; set; }

        [DisplayName("Site Url:")]
        public string SiteUrl { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DisplayName("Search Engine*:")]
        public int SearchEngineId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DisplayName("Region*:")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DisplayName("Keywords:")]
        public string Keywords { get; set; }

        public AddNewTaskViewModel()
        {
            SearchEngines = new List<SelectListItem>();
            Regions = new List<SelectListItem>();
        }
    }
}
