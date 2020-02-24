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
    public class AsignaturasController
    {
        public bool Insertar(Asignaturas Asignatura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (Asignatura.AsignaturaId == 0)
                {

                    paso = Guardar(Asignatura);
                }
                else
                {

                    paso = Modificar(Asignatura);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static bool Guardar(Asignaturas Asignatura)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Asignaturas.Add(Asignatura);
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

        public static bool Modificar(Asignaturas Asignatura)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(Asignatura).State = EntityState.Modified;
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
            Asignaturas Asignatura = contexto.Asignaturas.Find(Id);

            try
            {

                contexto.Entry(Asignatura).State = EntityState.Deleted;
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

        public Asignaturas Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Asignaturas Asignatura = new Asignaturas();

            try
            {

                Asignatura = contexto.Asignaturas.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return Asignatura;
        }

        public List<Asignaturas> GetList(Expression<Func<Asignaturas, bool>> expression)
        {

            Contexto contexto = new Contexto();
            List<Asignaturas> ListadoAsignaturas = new List<Asignaturas>();

            try
            {

                ListadoAsignaturas = contexto.Asignaturas.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return ListadoAsignaturas;
        }
    }
}
