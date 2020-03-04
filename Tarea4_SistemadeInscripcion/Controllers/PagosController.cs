using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tarea4_SistemadeInscripcion.Data;
using Tarea4_SistemadeInscripcion.Models;

namespace Tarea4_SistemadeInscripcion.Controllers
{
    public class PagosController
    {
        public bool Insertar(Pagos Pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (Pago.PagoId == 0)
                {

                    paso = Guardar(Pago);
                }
                else
                {

                    paso = Modificar(Pago);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static bool Guardar(Pagos Pago)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Estudiantes.Find(Pago.EstudianteId).Balance -= Pago.Monto;
                contexto.Pagos.Add(Pago);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Pagos Pago)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Pago).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public bool Eliminar(int Id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Pagos Pago = contexto.Pagos.Find(Id);
                contexto.Entry(Pago).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public Pagos Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Pagos Pago = new Pagos();

            try
            {

                Pago = contexto.Pagos.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return Pago;
        }

        public List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {

            Contexto contexto = new Contexto();
            List<Pagos> ListadoPagos = new List<Pagos>();

            try
            {

                ListadoPagos = contexto.Pagos.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return ListadoPagos;
        }
    }
}
