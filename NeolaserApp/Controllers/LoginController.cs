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
        public ActionResult ValidarUsuario(usuario user)
        {
            using (neolaserdbEntities db = new neolaserdbEntities())
            {
                var usr = db.usuarios.Single(u => u.email == user.email && u.contraseña == user.contraseña);
                if (usr != null)
                {
                    Session["userID"] = usr.id;
                    Session["userName"] = usr.nombre;
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