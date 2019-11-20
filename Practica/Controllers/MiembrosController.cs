using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Models;
namespace Practica.Controllers
{
    public class MiembrosController : Controller
    {
        Practica5Entities db = new Practica5Entities();

        // GET: Miembros
        [HttpGet]
        public ActionResult GetMembers()
        {

            var members = db.Miembros.Where(m => m.estado_asig == 1).ToList();
            ViewBag.Members = db.Miembros.Select(x => new SelectListItem { Text = x.nombre_miembro, Value = x.ID.ToString()});

            return View(members);
        }

        [HttpPost]
        public ActionResult AddMembers(Miembro model)
        {
            var members = new Miembro();

            if (ModelState.IsValid)
            {
                 members = new Miembro() {
                     nombre_miembro = model.nombre_miembro,
                     id_asig = model.id_asig,
                     estado_asig = model.estado_asig
                };
                db.Miembros.Add(members);

                return RedirectToAction("GetMembers");
            }
           

            return View(model);
        }

        [HttpGet]
        public ActionResult AddMembers()
        {

            ViewBag.Asignaturas = db.Asignaturas.Select(a => new SelectListItem()
            {
                Text = a.nombre_asig,
                Value = a.ID.ToString()
            });

            ViewBag.Estado = db.Estados.Select(e => new SelectListItem() {

                Text = e.nombre_estado,
                Value = e.ID.ToString()
            });

            return View();
        }
    }
}