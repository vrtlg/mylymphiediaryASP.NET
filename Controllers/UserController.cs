using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MLD.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}