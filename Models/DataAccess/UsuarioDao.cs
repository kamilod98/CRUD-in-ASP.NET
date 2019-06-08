using Registro.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registro.Models.DataAccess
{
    public class UsuarioDao
    {
        /// <summary>
        /// Este metodo almacena registros de la tabla Usuario
        /// </summary>
        /// <param name="usuarioModel">Es un objeto tipo UsuarioModel</param>
        public void Crear(UsuarioModel usuarioModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                //Corresponde a la creacion de una instancia para una nueva fila
                Usuario a = new Usuario();
                a.Nombre = usuarioModel.Nombre;
                a.Email = usuarioModel.Email;
                a.Genero = usuarioModel.Genero;
                a.Pais = usuarioModel.Pais;

                contexto.Usuario.Add(a);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Este metodo permite eliminar un usuario a partir del id
        /// </summary>
        /// <param name="usuarioModel"></param>
        public void Eliminar(UsuarioModel usuarioModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                var usuarioaeliminar = (from x in contexto.Usuario select x).Where(d => d.Id.Equals(usuarioModel.Id)).FirstOrDefault();

                contexto.Usuario.Remove(usuarioaeliminar);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Este metodo permite actualizar la informacion del usuario a partir del id
        /// </summary>
        /// <param name="usuarioModel"></param>
        public void Actualizar(UsuarioModel usuarioModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                var usuarioenbd = (from x in contexto.Usuario select x).Where(d => d.Id.Equals(usuarioModel.Id)).FirstOrDefault();

                usuarioenbd.Nombre = usuarioModel.Nombre;
                usuarioenbd.Pais = usuarioModel.Pais;
                usuarioenbd.Genero = usuarioModel.Genero;
                usuarioenbd.Email = usuarioModel.Email;

                contexto.SaveChanges();
            }
            
        }

        /// <summary>
        /// Metodo que retorna todas las filas de la tabla usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioModel> Consultar()
        {
            List<UsuarioModel> listaresultaos = new List<UsuarioModel>();
            //1. Conectarme a la base de datos
            using (var contexto = new UsuariosEntities())
            {
                //2. Consultar los datos (objetos) linq
                List<Usuario> usuariosConsultados = (from x in contexto.Usuario select x).ToList();
                //3. Mapear los datos de modelo de datos al modelo del dominio
                foreach (Usuario u in usuariosConsultados)
                {
                    UsuarioModel usuarioModel = new UsuarioModel();
                    usuarioModel.Id = u.Id;
                    usuarioModel.Email = u.Email;
                    usuarioModel.Genero = u.Genero1.Nombre;
                    usuarioModel.Nombre = u.Nombre;
                    usuarioModel.Pais = u.Pais1.Nombre;
                    listaresultaos.Add(usuarioModel);
                }
            }

            //4. Retomar la lista con los datos del modelo del dominio
            return listaresultaos;
        }

        public UsuarioModel ObtenerUsuario(decimal Id)
        {
            UsuarioModel usuarioaretornar = new UsuarioModel();
            using (var contexto = new UsuariosEntities())
            {
                var usu = (from x in contexto.Usuario select x).Where(u => u.Id.Equals(Id)).FirstOrDefault();

                usuarioaretornar.Id = usu.Id;
                usuarioaretornar.Nombre = usu.Nombre;
                usuarioaretornar.Pais = usu.Pais;
                usuarioaretornar.Genero = usu.Genero;
                usuarioaretornar.Email = usu.Email;
            }
            return usuarioaretornar;
        }
    }
}
