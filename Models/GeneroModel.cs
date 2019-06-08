using Registro.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registro.Models
{
    public class GeneroModel
    {
        [Required]
        [StringLength(2, ErrorMessage = "La abreviacion del genero no puede superar los 2 caracteres")]
        [Display(Name = "Abreviacion del genero")]
        public string Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El nombre del genero no puede superar los 15 caracteres")]
        [Display(Name = "Nombre del genero")]
        public string Nombre { get; set; }

        public List<GeneroModel> Generos { get; set; }

        public void Guardar()
        {
            GeneroDao generoDao = new GeneroDao();
            generoDao.Crear(this);
            return;
        }

        public List<GeneroModel> ConsultarGeneros()
        {
            GeneroDao generoDao = new GeneroDao();
            List<GeneroModel> resultados = generoDao.Consultar();
            return resultados;
        }

        public void ActualizarGenero()
        {
            GeneroDao generoDao = new GeneroDao();
            generoDao.Actualizar(this);
        }

        public void EliminarGenero()
        {
            GeneroDao generoDao = new GeneroDao();
            generoDao.Eliminar(this);
        }

        public GeneroModel ObtenerGenero(string Id)
        {
            GeneroDao generoDao = new GeneroDao();
            return generoDao.ObtenerGenero(Id);
        }
    }
}