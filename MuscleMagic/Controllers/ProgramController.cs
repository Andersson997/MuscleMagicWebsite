using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuscleMagic.Models;




namespace MuscleMagic.Controllers
{
    public class ProgramController : Controller
    {
       
        [Authorize]
        public IActionResult Programs()
        {
            using (MMcontext db = new MMcontext())
            {
                var vm = new ExerciseListViewModel();
                string getemail = HttpContext.Session.GetString("email");
                var userid = db.Users.Where(u => u.Email == getemail).FirstOrDefault();
                var programid = db.Programs.Where(u => u.ProgramName == "Upper/Lower").FirstOrDefault();
                vm.UserId = userid.Id;
                vm.ProgramId = programid.Id;

                
                var exerciselist1 = new List<Exercise>();
                var exerciselist2 = new List<Exercise>();
                var exerciselist3 = new List<Exercise>();
                var exerciselist4 = new List<Exercise>();
                var exercise1 = db.Exercises.Find(1);
                var exercise2 = db.Exercises.Find(2);
                var exercise3 = db.Exercises.Find(3);
                var exercise4 = db.Exercises.Find(4);
                var exercise5 = db.Exercises.Find(5);
                var exercise6 = db.Exercises.Find(6);
                var exercise7 = db.Exercises.Find(7);
                var exercise8 = db.Exercises.Find(8);
                var exercise9 = db.Exercises.Find(9);
                var exercise10 = db.Exercises.Find(10);
                var exercise11 = db.Exercises.Find(11);
                var exercise12 = db.Exercises.Find(12);
                var exercise13 = db.Exercises.Find(13);
                var exercise14 = db.Exercises.Find(14);
                var exercise15 = db.Exercises.Find(15);
                var exercise16 = db.Exercises.Find(16);
                var exercise17 = db.Exercises.Find(17);
                var exercise18 = db.Exercises.Find(18);
                var exercise19 = db.Exercises.Find(19);
                var exercise20 = db.Exercises.Find(20);
                var exercise21 = db.Exercises.Find(21);
                var exercise22 = db.Exercises.Find(22);
                var exercise23 = db.Exercises.Find(23);
                var exercise24 = db.Exercises.Find(24);
                var exercise25 = db.Exercises.Find(25);
                exerciselist1.Add(exercise1);
                exerciselist1.Add(exercise2);
                exerciselist1.Add(exercise3);
                exerciselist1.Add(exercise4);
                exerciselist1.Add(exercise5);
                exerciselist1.Add(exercise6);
                exerciselist1.Add(exercise7);
                exerciselist2.Add(exercise8);
                exerciselist2.Add(exercise9);
                exerciselist2.Add(exercise10);
                exerciselist2.Add(exercise11);
                exerciselist2.Add(exercise12);
                exerciselist2.Add(exercise13);
                exerciselist3.Add(exercise14);
                exerciselist3.Add(exercise15);
                exerciselist3.Add(exercise16);
                exerciselist3.Add(exercise17);
                exerciselist3.Add(exercise18);
                exerciselist3.Add(exercise19);
                exerciselist4.Add(exercise20);
                exerciselist4.Add(exercise21);
                exerciselist4.Add(exercise22);
                exerciselist4.Add(exercise23);
                exerciselist4.Add(exercise24);
                exerciselist4.Add(exercise25);

                vm.exerciselist1 = exerciselist1;
                vm.exerciselist2 = exerciselist2;
                vm.exerciselist3 = exerciselist3;
                vm.exerciselist4 = exerciselist4;
                return View(vm);
            }
          
        }
        public IActionResult AddProgramtoUser(int id, int id2)
        {
            using (MMcontext db = new MMcontext())
            {
                
                var ProgramUser = db.Programs.Find(id);
                var UserProgram  = db.Users.Find(id2);
                ProgramUser.Users = new List<User>();
                UserProgram.Programs = new List<Exerciseschedule>();
                ProgramUser.Users.Add(UserProgram);
                UserProgram.Programs.Add(ProgramUser);

                if (UserProgram.Programs.Where(o => o.Id == id).Count() == 1)
                {
                    db.Entry(ProgramUser).State = EntityState.Modified;
                    db.SaveChanges();
                    db.Entry(UserProgram).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Myaccount", "Home");
            }
            
        }
    }
}

