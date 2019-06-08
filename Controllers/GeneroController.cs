using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registro.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GeneroModel generoModel)
        {
            if (ModelState.IsValid)
            {
                generoModel.Guardar();
                return RedirectToAction("GuardadoExitoso");
            }
            else
            {
                return View();
            }

        }

        public ActionResult GuardadoExitoso()
        {
            return View();
        }

        public ActionResult Modificar(string Id)
        {
            GeneroModel ge = new GeneroModel();
            ge = ge.ObtenerGenero(Id);
            return View(ge);
        }

        public ActionResult ObtenerGeneros()
        {
            GeneroModel generoModel = new GeneroModel();
            generoModel.Generos = generoModel.ConsultarGeneros();

            return View(generoModel);
        }

        [HttpPost]
        public ActionResult Modificar(GeneroModel ge)
        {
            if (ModelState.IsValid)
            {
                ge.ActualizarGenero();
                return RedirectToAction("GuardadoExitoso");
            }
            else
            {
                return View(ge);
            }

        }

        public ActionResult Confirmacion(string Id)
        {
            ViewBag.IdEliminar = Id;
            return View();
        }

        public ActionResult Eliminar(string IdEliminar)
        {
            GeneroModel ge = new GeneroModel();
            ge.Id = IdEliminar;
            ge.EliminarGenero();
            return RedirectToAction("ObtenerGeneros");
        }
    }
}
