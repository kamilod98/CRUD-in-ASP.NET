using Registro.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registro.Models.DataAccess
{
    public class PaisDao
    {
        public void Crear(PaisModel paisModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                Pais p = new Pais();
                p.Id = paisModel.Id;
                p.Nombre = paisModel.Nombre;

                contexto.Pais.Add(p);
                contexto.SaveChanges();
            }
        }

        public void Eliminar(PaisModel paisModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                var paisaeliminar = (from x in contexto.Pais select x).Where(d => d.Id.Equals(paisModel.Id)).FirstOrDefault();

                contexto.Pais.Remove(paisaeliminar);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(PaisModel paisModel)
        {
            using (var contexto = new UsuariosEntities())
            {
                var paisenbd = (from x in contexto.Pais select x).Where(d => d.Id.Equals(paisModel.Id)).FirstOrDefault();

                paisenbd.Id = paisModel.Id;
                paisenbd.Nombre = paisModel.Nombre;

                contexto.SaveChanges();
            }

        }

        public List<PaisModel> Consultar()
        {
            List<PaisModel> listaresultados = new List<PaisModel>();
            using (var contexto = new UsuariosEntities())
            {
                List<Pais> paisesConsultados = (from x in contexto.Pais select x).ToList();
                foreach (Pais p in paisesConsultados)
                {
                    PaisModel paisModel = new PaisModel();
                    paisModel.Id = p.Id;
                    paisModel.Nombre = p.Nombre;
                    listaresultados.Add(paisModel);
                }
            }
            return listaresultados;
        }

        public PaisModel ObtenerPais(string Id)
        {
            PaisModel paisaretornar = new PaisModel();
            using (var contexto = new UsuariosEntities())
            {
                var pa = (from x in contexto.Pais select x).Where(p => p.Id.Equals(Id)).FirstOrDefault();

                paisaretornar.Id = pa.Id;
                paisaretornar.Nombre = pa.Nombre;
            }
            return paisaretornar;
        }
    }
}
