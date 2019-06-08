using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registro.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            DevolverPaises();
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioModel usuarioModel)
        {
            DevolverPaises();
            if (ModelState.IsValid)
            {
                usuarioModel.Guardar();
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

        public ActionResult Modificar(decimal Id)
        {
            DevolverPaises();
            UsuarioModel usu = new UsuarioModel();
            usu = usu.ObtenerUsuario(Id);
            return View(usu);
        }

        public ActionResult ObtenerUsuarios()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Usuarios = usuarioModel.ConsultarUsuarios();

            return View(usuarioModel);
        }

        private void DevolverPaises()
        {
            PaisModel p = new PaisModel();
            List<SelectListItem> listapaises = new List<SelectListItem>();

            foreach (var e in p.ObtenerPaises())
            {
                SelectListItem elemento = new SelectListItem();
                elemento.Value = e.Id;
                elemento.Text = e.Nombre;
                listapaises.Add(elemento);
            }

            ViewBag.Paises = listapaises;
        }

        [HttpPost]
        public ActionResult Modificar(UsuarioModel usu)
        {
            if (ModelState.IsValid)
            {
                usu.ActualizarUsuario();
                return RedirectToAction("GuardadoExitoso");
            }
            else
            {
                DevolverPaises();
                return View(usu);
            }
            
        }

        public ActionResult Eliminar(decimal IdEliminar)
        {
            UsuarioModel usu = new UsuarioModel();
            usu.Id = IdEliminar;
            usu.EliminarUsuario();
            return RedirectToAction("ObtenerUsuarios");
        }

    }
}
