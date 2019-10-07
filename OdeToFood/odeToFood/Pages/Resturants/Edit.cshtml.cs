using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace odeToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (resturantId.HasValue)
                Resturant = resturantData.getById(resturantId.Value);
            else
                Resturant = new Resturant();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Resturant.Id > 0)
                resturantData.update(Resturant);
            else
                resturantData.Add(Resturant);
            TempData["Message"] = "Saved Successfully";
            return RedirectToPage("./Detail", new { resturantId = Resturant.Id });

        }
    }
}