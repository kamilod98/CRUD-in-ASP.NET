using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registro.Controllers
{
    public class PaisController : Controller
    {
        // GET: Pais
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PaisModel paisModel)
        {
            if (ModelState.IsValid)
            {
                paisModel.GuardarPais();
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
            PaisModel pa = new PaisModel();
            pa = pa.ObtenerPais(Id);
            return View(pa);
        }

        public ActionResult ObtenerPaises()
        {
            PaisModel paisModel = new PaisModel();
            paisModel.Paises = paisModel.ConsultarPaises();

            return View(paisModel);
        }

        [HttpPost]
        public ActionResult Modificar(PaisModel pa)
        {
            if (ModelState.IsValid)
            {
                pa.ActualizarPais();
                return RedirectToAction("GuardadoExitoso");
            }
            else
            {
                return View(pa);
            }

        }

        public ActionResult Confirmacion(string Id)
        {
            ViewBag.IdEliminar = Id;
            return View();
        }

        public ActionResult Eliminar(string IdEliminar)
        {
            PaisModel pa = new PaisModel();
            pa.Id = IdEliminar;
            pa.EliminarPais();
            return RedirectToAction("ObtenerPaises");
        }
    }
}
