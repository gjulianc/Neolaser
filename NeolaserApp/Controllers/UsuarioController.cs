using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeolaserApp.Models;

namespace NeolaserApp.Controllers
{
    public class UsuarioController : Controller
    {
        private neolaserdbEntities db = new neolaserdbEntities();

        // GET: /tUsuarios/
        public ActionResult Index()
        {
            var tusuarios = db.tUsuarios.Include(t => t.tCliente).Include(t => t.tRole);
            return View(tusuarios.ToList());
        }

        // GET: /tUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tUsuario tUsuario = db.tUsuarios.Find(id);
            if (tUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tUsuario);
        }

        // GET: /tUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.FkCliente = new SelectList(db.tClientes, "Id", "Cif");
            ViewBag.FkRol = new SelectList(db.tRoles, "Id", "Descripion");
            return View();
        }

        // POST: /tUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Apellido1,Apellido2,Telefono,Email,user,Password,Foto,FkRol,FkCliente")] tUsuario tUsuario)
        {
            if (ModelState.IsValid)
            {
                db.tUsuarios.Add(tUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkCliente = new SelectList(db.tClientes, "Id", "Cif", tUsuario.FkCliente);
            ViewBag.FkRol = new SelectList(db.tRoles, "Id", "Descripion", tUsuario.FkRol);
            return View(tUsuario);
        }

        // GET: /tUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tUsuario tUsuario = db.tUsuarios.Find(id);
            if (tUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkCliente = new SelectList(db.tClientes, "Id", "Cif", tUsuario.FkCliente);
            ViewBag.FkRol = new SelectList(db.tRoles, "Id", "Descripion", tUsuario.FkRol);
            return View(tUsuario);
        }

        // POST: /tUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Apellido1,Apellido2,Telefono,Email,user,Password,Foto,FkRol,FkCliente")] tUsuario tUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkCliente = new SelectList(db.tClientes, "Id", "Cif", tUsuario.FkCliente);
            ViewBag.FkRol = new SelectList(db.tRoles, "Id", "Descripion", tUsuario.FkRol);
            return View(tUsuario);
        }

        // GET: /tUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tUsuario tUsuario = db.tUsuarios.Find(id);
            if (tUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tUsuario);
        }

        // POST: /tUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tUsuario tUsuario = db.tUsuarios.Find(id);
            db.tUsuarios.Remove(tUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
