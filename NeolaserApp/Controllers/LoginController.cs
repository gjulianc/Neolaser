using NeolaserApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeolaserApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarUsuario(tUsuario _user)
        {
            using (neolaserdbEntities db = new neolaserdbEntities())
            {
                var usr = db.tUsuarios.Single(u => u.Email == _user.Email && u.Password == _user.Password);
                if (usr != null)
                {
                    Session["userID"] = usr.Id;
                    Session["userName"] = usr.Nombre;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o Contraseña erroneas.");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}