using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wrBlogs.Net.ViewModel;

namespace wrBlogs.Net.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }
    }
}