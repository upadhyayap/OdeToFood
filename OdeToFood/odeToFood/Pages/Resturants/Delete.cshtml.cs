using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace odeToFood.Pages.Resturants
{
    public class DeleteModel : PageModel
    {
        public Resturant Resturant { get; set; }
        private readonly IResturantData resturantData;

        public DeleteModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.getById(resturantId);
            if(Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int resturantId)
        {
            Resturant resturant = resturantData.delete(resturantId);
            if (resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["message"] = $"{resturant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}