using Registro.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registro.Models
{
    public class PaisModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "La abreviacion no puede superar los 3 caracteres")]
        [Display(Name = "Abreviacion del pais")]
        public string Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "EL nombre del pais no puede superar los 50 caracteres")]
        [Display(Name = "Nombre del pais")]
        public string Nombre { get; set; }

        public List<PaisModel> ObtenerPaises()
        {
            PaisDao paisDao = new PaisDao();
            return paisDao.Consultar();
        }

        public List<PaisModel> Paises { get; set; }

        public void GuardarPais()
        {
            PaisDao paisDao = new PaisDao();
            paisDao.Crear(this);
            return;
        }

        public List<PaisModel> ConsultarPaises()
        {
            PaisDao paisDao = new PaisDao();
            List<PaisModel> resultados = paisDao.Consultar();
            return resultados;
        }

        public void ActualizarPais()
        {
            PaisDao paisDao = new PaisDao();
            paisDao.Actualizar(this);
        }

        public void EliminarPais()
        {
            PaisDao paisDao = new PaisDao();
            paisDao.Eliminar(this);
        }

        public PaisModel ObtenerPais(string Id)
        {
            PaisDao paisDao = new PaisDao();
            return paisDao.ObtenerPais(Id);
        }
    }
}