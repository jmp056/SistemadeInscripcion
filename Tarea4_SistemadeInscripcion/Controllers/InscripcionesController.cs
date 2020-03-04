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
    public class InscripcionesController
    {
        public bool Insertar(Inscripciones Inscripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (Inscripcion.InscripcionId == 0)
                {

                    paso = Guardar(Inscripcion);
                }
                else
                {

                    paso = Modificar(Inscripcion);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static bool Guardar(Inscripciones Inscripcion)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            EstudiantesController estudiantesController = new EstudiantesController();

            try
            {

                var Estudiante = estudiantesController.Buscar(Inscripcion.EstudianteId);
                Estudiante.Balance += Inscripcion.Monto;
                estudiantesController.Insertar(Estudiante);

                contexto.Inscripciones.Add(Inscripcion);
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

        public static bool Modificar(Inscripciones Inscripcion)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            InscripcionesController inscripcionesController = new InscripcionesController();
            EstudiantesController estudiantesController = new EstudiantesController();

            try
            {
                var Estudiante = estudiantesController.Buscar(Inscripcion.EstudianteId);
                var InscripcionAnterior = inscripcionesController.Buscar(Inscripcion.InscripcionId);

                Estudiante.Balance -= InscripcionAnterior.Monto;
                contexto.Inscripciones.Add(Inscripcion);

                foreach (var item in InscripcionAnterior.DetalleAsignaturas)
                {
                    if (!Inscripcion.DetalleAsignaturas.Any(p => p.InscripcionDetalleId == item.InscripcionDetalleId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in Inscripcion.DetalleAsignaturas)
                {
                    if (item.InscripcionDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }

                Estudiante.Balance += Inscripcion.Monto;
                estudiantesController.Insertar(Estudiante);

                contexto.Entry(Inscripcion).State = EntityState.Modified;
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
            Inscripciones Inscripcion = new Inscripciones();
            EstudiantesController estudiantesController = new EstudiantesController();
            

            try
            {
                Inscripcion = contexto.Inscripciones.Find(Id);
                contexto.Estudiantes.Find(Inscripcion.EstudianteId).Balance -= Inscripcion.Monto;

                //contexto.Entry(Inscripcion).State = EntityState.Deleted;
                contexto.Inscripciones.Remove(Inscripcion);
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

        public Inscripciones Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Inscripciones Inscripcion = new Inscripciones();
            InscripcionDetalleController inscripcionDetalleController = new InscripcionDetalleController();

            try
            {

                Inscripcion = contexto.Inscripciones.Find(Id);
                if(Inscripcion != null)
                {

                    Inscripcion.DetalleAsignaturas = inscripcionDetalleController.GetList(p => p.InscripcionId == Id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return Inscripcion;
        }

        public List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> expression)
        {

            Contexto contexto = new Contexto();
            List<Inscripciones> ListadoInscripciones = new List<Inscripciones>();

            try
            {

                ListadoInscripciones = contexto.Inscripciones.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return ListadoInscripciones;
        }
    }
}
