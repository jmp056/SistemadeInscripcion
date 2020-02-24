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
    public class EstudiantesController
    {
        public bool Insertar(Estudiantes Estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (Estudiante.EstudianteId == 0)
                {

                    paso = Guardar(Estudiante);
                }
                else
                {

                    paso = Modificar(Estudiante);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static bool Guardar(Estudiantes Estudiante)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Estudiantes.Add(Estudiante);
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

        public static bool Modificar(Estudiantes Estudiante)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(Estudiante).State = EntityState.Modified;
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
            Estudiantes Estudiante = contexto.Estudiantes.Find(Id);

            try
            {

                contexto.Entry(Estudiante).State = EntityState.Deleted;
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

        public Estudiantes Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Estudiantes Estudiante = new Estudiantes();

            try
            {

                Estudiante = contexto.Estudiantes.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return Estudiante;
        }

        public List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> expression)
        {

            Contexto contexto = new Contexto();
            List<Estudiantes> ListadoEstudiantes = new List<Estudiantes>();

            try
            {

                ListadoEstudiantes = contexto.Estudiantes.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return ListadoEstudiantes;
        }
    }
}
