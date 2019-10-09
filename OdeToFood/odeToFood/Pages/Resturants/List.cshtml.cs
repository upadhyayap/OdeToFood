using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace odeToFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IResturantData resturantData;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<Resturant> Resturants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IResturantData resturantData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.resturantData = resturantData;
            this.logger = logger;
        }
        public string Message { get; set; }

        public void OnGet()
        {
            logger.LogError("Executing Resturant list");
            Message = config["Message"];
            Resturants = resturantData.GetResturantsByName(SearchTerm);
        }
    }
}