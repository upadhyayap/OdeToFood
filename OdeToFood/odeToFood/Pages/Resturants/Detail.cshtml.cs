﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace odeToFood.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        private readonly IResturantData resturantData;

        public Resturant Resturant { get; set; }
        [TempData]
        public string Message { get; set; }
        public DetailModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.getById(resturantId);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}