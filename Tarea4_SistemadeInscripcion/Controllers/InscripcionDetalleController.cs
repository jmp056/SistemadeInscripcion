using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tarea4_SistemadeInscripcion.Data;
using Tarea4_SistemadeInscripcion.Models;

namespace Tarea4_SistemadeInscripcion.Controllers
{
    public class InscripcionDetalleController
    {
        public List<InscripcionDetalle> GetList(Expression<Func<InscripcionDetalle, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<InscripcionDetalle> lista;

            try
            {

                lista = contexto.InscripcionDetalles.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return lista;
        }
        public InscripcionDetalle Buscar(int id)
        {
            Contexto contexto = new Contexto();
            InscripcionDetalle inscripcionDetalle = new InscripcionDetalle();

            try
            {

                inscripcionDetalle = contexto.InscripcionDetalles.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return inscripcionDetalle;
        }
    }
}
