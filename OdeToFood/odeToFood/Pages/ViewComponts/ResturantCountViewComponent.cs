using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odeToFood.Pages.ViewComponts
{
    public class ResturantCountViewComponent : ViewComponent
    {
        private readonly IResturantData resturantdata;

        public ResturantCountViewComponent(IResturantData resturantdata)
        {
            this.resturantdata = resturantdata;
        }

        public IViewComponentResult Invoke()
        {
            var count = resturantdata.getResturantCount();

            return View(count);
        }
    }
}
