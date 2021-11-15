using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.App.Controllers
{
    public class ProvasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
