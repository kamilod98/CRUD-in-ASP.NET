using Registro.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registro.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "Debes ingresar un Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "No parece un correo")]
        [StringLength(50, ErrorMessage = "Tu correo electronico no puede superar 50 caracteres")]
        [Display(Name ="Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Tu nombre no puede superar 100 caracteres")]
        [Display(Name ="Nombre Completo")]
        public string Nombre { get; set; }

        [Display(Name = "Pais de Origen")]
        public string Pais { get; set; }

        [Display(Name = "Sexo")]
        public string Genero { get; set; }

        public List<UsuarioModel> Usuarios { get; set; }

        public decimal Id { get; set; }

        public void Guardar()
        {
            //1. Instanciar al Dao
            UsuarioDao usuarioDao = new UsuarioDao();
            //1.1 Incluir validaciones personalizadas
            //2. Invocar al metodo crear
            usuarioDao.Crear(this);
            return;
        }

        public List<UsuarioModel> ConsultarUsuarios()
        {
            //1. Instanciar al Dao
            UsuarioDao usuarioDao = new UsuarioDao();
            //2. Invocar al Dao
            List<UsuarioModel> resultados = usuarioDao.Consultar();
            //3. Incluir validaciones de negocio
            //4. Retornar el lsitado
            return resultados;
        }

        public void ActualizarUsuario()
        {
            UsuarioDao usuarioDao = new UsuarioDao();
            usuarioDao.Actualizar(this);
        }

        public void EliminarUsuario()
        {
            UsuarioDao usuarioDao = new UsuarioDao();
            usuarioDao.Eliminar(this);
        }

        public UsuarioModel ObtenerUsuario(decimal Id)
        {
            UsuarioDao usuarioDao = new UsuarioDao();
            return usuarioDao.ObtenerUsuario(Id);
        }
    }
}