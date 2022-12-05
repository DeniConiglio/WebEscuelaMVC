using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {

        private EscuelaDBMVC context = new EscuelaDBMVC();

        // GET: Aula
        public ActionResult Index()
        {
            List<Aula> lista = context.Aulas.ToList();
            return View("Index", lista);
        }



        //GET: Aula/Create
        public ActionResult Create()
        {
            Aula aula = new Aula();
            return View("Register", aula);
        }

        [HttpPost]
        //POST: Aula/Create
        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Aulas.Add(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Register", aula);

        }


        //GET: Aula/id
        public ActionResult Details(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                HttpNotFound();
            }
            return View("Details", aula);

        }


        //GET
        public ActionResult Delete(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Delete", aula);
        }

        [HttpPost]
        //POST
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula != null)
            {
                context.Aulas.Remove(aula);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //GET:Aula/Edit/id
        public ActionResult Edit(int id)
        {

            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                HttpNotFound();

            }
            return View("Edit", aula);

        }

        //POST : Aula/Edit/id
        [HttpPost]

        public ActionResult Edit(Aula aula)
        {

            if (ModelState.IsValid)
            {

                context.Entry(aula).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aula);

        }


        public ActionResult ListarPorEstado(string estado)
        {
            List<Aula> aulaEstado = (from e in context.Aulas where estado == e.Estado select e).ToList();
            return View("Index", aulaEstado);

        }


        public ActionResult TraerPorNumero(int num)
        {
            dynamic aulaNum = (from a in context.Aulas where num == a.Numero select a).ToList();
            return View("Detail", aulaNum);
        }

    }
}
