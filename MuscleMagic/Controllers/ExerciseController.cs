using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MuscleMagic.Controllers
{
    public class ExerciseController : Controller
    {
        
        public IActionResult Muscle_group_selection()
        {
            return View();
        }
    }
}

