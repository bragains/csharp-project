using My_project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using My_project.Repositories;
using System.Net;

namespace My_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Page currently being developed. Please check back soon.";

            return View();
        }

        public ActionResult Invest()
        {
            ViewBag.Message = "Page currently being developed. Please check back soon.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Thanks for your interest in Kimberley Mining. We look forward to hearing from you.";

            return View();
        }

        // CREATE USER

        public ActionResult CreateUser()
        {
            return View("AddUser");
        }


        // ADD USER

        public ActionResult AddUser(User user)
        {
            using (var repo = new UserRepository())
            {
                repo.AddUser(user);
                return View("SingleUser", user);
            }     
        }

        // VIEW USERS

        public ActionResult ViewUsers()
        {
            using (var repo = new UserRepository())
            {
                return View("UserList", repo.Users.ToList());
            }
        }

        // EDIT USER

        public ActionResult EditUser(int id)
        {
            using (var repo = new UserRepository())
            {
                return View("EditUser", repo.GetUser(id));
            }
        }

        // UPDATE USER

        public ActionResult UpdateUser(User user)
        {
            using (var repo = new UserRepository())
            {
                repo.EditUser(user);
                return View("UserList", repo.Users.ToList());
            }
        }

        // DELETE USER

        public ActionResult RemoveUser(int id)
        {
            using (var repo = new UserRepository())
            {
                return View("DeleteUser", repo.RetrieveUser(id));
            }
        }

        
        public ActionResult DeleteUser(User user)
        {
            using (var repo = new UserRepository())
            {
               repo.RemoveUser(user);
               return View("UserList", repo.Users.ToList());
           }
       }

    }

}