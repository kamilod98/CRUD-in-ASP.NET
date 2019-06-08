using Registro.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registro.Models.DataAccess
{
    public class GeneroDao
    {
        public void Crear(GeneroModel generoModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                Genero g = new Genero();
                g.Id = generoModel.Id;
                g.Nombre = generoModel.Nombre;

                contexto.Genero.Add(g);
                contexto.SaveChanges();
            }
        }

        public void Eliminar(GeneroModel generoModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                var generoaeliminar = (from x in contexto.Genero select x).Where(d => d.Id.Equals(generoModel.Id)).FirstOrDefault();

                contexto.Genero.Remove(generoaeliminar);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(GeneroModel generoModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                var generoenbd = (from x in contexto.Genero select x).Where(d => d.Id.Equals(generoModel.Id)).FirstOrDefault();

                generoenbd.Id = generoModel.Id;
                generoenbd.Nombre = generoModel.Nombre;

                contexto.SaveChanges();
            }

        }

        public List<GeneroModel> Consultar()
        {
            List<GeneroModel> listaresultados = new List<GeneroModel>();
            using (var contexto = new UsuariosEntities())
            {
                List<Genero> generosConsultados = (from x in contexto.Genero select x).ToList();
                foreach (Genero g in generosConsultados)
                {
                    GeneroModel generoModel = new GeneroModel();
                    generoModel.Id = g.Id;
                    generoModel.Nombre = g.Nombre;

                    listaresultados.Add(generoModel);
                }
            }
            return listaresultados;
        }

        public GeneroModel ObtenerGenero(string Id)
        {
            GeneroModel generoaretornar = new GeneroModel();
            using (var contexto = new UsuariosEntities())
            {
                var ge = (from x in contexto.Genero select x).Where(g => g.Id.Equals(Id)).FirstOrDefault();

                generoaretornar.Id = ge.Id;
                generoaretornar.Nombre = ge.Nombre;
            }
            return generoaretornar;
        }
    }
}
