
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MuscleMagic.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;


namespace MuscleMagic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (MMcontext db = new MMcontext())
            {
                var exercise = db.Exercises.FirstOrDefault();
                if (exercise == null)
                {
                    Exercise exercise1 = new Exercise("Bench press", 8,3);
                    Exercise exercise2 = new Exercise("Pullups",8,3);
                    Exercise exercise3 = new Exercise("Incline bench press",10,3);
                    Exercise exercise4 = new Exercise("Inverted rows",15,3);
                    Exercise exercise5 = new Exercise("Pullover",10,3);
                    Exercise exercise6 = new Exercise("Cable lateral raise",12,3);
                    Exercise exercise7 = new Exercise("Cable rear flys",12,3);
                    Exercise exercise8 = new Exercise("Squats", 12, 3);
                    Exercise exercise9 = new Exercise("Romanian deadlift", 12, 3);
                    Exercise exercise10 = new Exercise("Single leg press", 12, 3);
                    Exercise exercise11 = new Exercise("Leg extension", 12, 3);
                    Exercise exercise12 = new Exercise("Leg curls", 12, 3);
                    Exercise exercise13 = new Exercise("Standing calf raise", 12, 3);
                    Exercise exercise14 = new Exercise("Shoulder press", 12, 3);
                    Exercise exercise15 = new Exercise("Closegrip bench", 12, 3);
                    Exercise exercise16 = new Exercise("Chest supported rows", 12, 3);
                    Exercise exercise17 = new Exercise("Ring dips", 12, 3);
                    Exercise exercise18 = new Exercise("Lateral raise", 12, 3);
                    Exercise exercise19 = new Exercise("Deadlift", 12, 3);
                    Exercise exercise20 = new Exercise("Hack Squats", 12, 3);
                    Exercise exercise21 = new Exercise("Single leg Hip thrust", 12, 3);
                    Exercise exercise22 = new Exercise("Single leg Calf raise", 12, 3);
                    Exercise exercise23 = new Exercise("Hammer curls", 12, 3);
                    Exercise exercise24 = new Exercise("Cable bicep curl", 12, 3);
                    Exercise exercise25 = new Exercise("Tricep pushdown", 12, 3);


                    Exerciseschedule schedule1 = new Exerciseschedule("Upper/Lower");
                        db.Add(exercise1);
                        db.Add(exercise2);
                        db.Add(exercise3);
                        db.Add(exercise4);
                        db.Add(exercise5);
                        db.Add(exercise6);
                        db.Add(exercise7);
                        db.Add(exercise8);
                        db.Add(exercise9);
                        db.Add(exercise10);
                        db.Add(exercise11);
                        db.Add(exercise12);
                        db.Add(exercise13);
                        db.Add(exercise14);
                        db.Add(exercise15);
                        db.Add(exercise16);
                        db.Add(exercise17);
                        db.Add(exercise18);
                        db.Add(exercise19);
                        db.Add(exercise20);
                        db.Add(exercise21);
                        db.Add(exercise22);
                        db.Add(exercise23);
                        db.Add(exercise24);
                        db.Add(exercise25);
                        db.Add(schedule1);
                        db.SaveChanges();
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<bool> Register(string fname, string lname, string email, string password)
        {

            using (MMcontext db = new MMcontext())
            {
                var Users = db.Users.Where(u => u.Email == email).FirstOrDefault();

                if (Users == null)
                {
                    User newUser = new User();
                    newUser.FirstName = fname;
                    newUser.LastName = lname;
                    newUser.Email = email;
                    newUser.Password = password;
                    db.Add(newUser);
                    db.SaveChanges();
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Email, newUser.Email));
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                    HttpContext.Session.SetString("email", email);
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

       

        [HttpPost]
        public async Task<bool> Index(string email, string password)
        {
            User currentUser = new User();
            currentUser.Email = email;
            currentUser.Password = password;
            bool userOk = CheckUserFromDB(currentUser);
            if (userOk == true)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, currentUser.Email));
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
                HttpContext.Session.SetString("email",email);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private bool CheckUserFromDB(User userInfo)
        {


            using (MMcontext database = new MMcontext())
            {
                var validUser = database.Users.Where(u => u.Email == userInfo.Email).Where(k => k.Password == userInfo.Password).FirstOrDefault();
                if (validUser == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }
       
        public async Task<IActionResult> SignOutUser()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

       
        public IActionResult Myaccount()
        {
            string getemail = HttpContext.Session.GetString("email");

            using (MMcontext db = new MMcontext())
            {
                var fname = db.Users.Where(u => u.Email == getemail).FirstOrDefault();
                return View(fname);

            }

           
        }

        public IActionResult EditAccount(int id)
        {
            using (MMcontext db = new MMcontext())
            {
                var EditUser = db.Users.Find(id);
                return View(EditUser);
            }
        }
        [HttpPost]
        public IActionResult EditAccount(User updatedUser)
        {

            using (MMcontext database = new MMcontext())
            {
                database.Entry(updatedUser).State = EntityState.Modified;
                database.SaveChanges();
            }
            
            return RedirectToAction("Myaccount");
        }
        [HttpPost]
        public IActionResult Delete(User deletedUser)
        {
            using (MMcontext database = new MMcontext())
            {
                database.Remove(deletedUser);
                database.SaveChanges();
            }
            
            return RedirectToAction("SignOutUser");
        }
    }
}

