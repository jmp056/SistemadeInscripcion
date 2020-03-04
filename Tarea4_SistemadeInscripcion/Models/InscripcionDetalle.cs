using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea4_SistemadeInscripcion.Models
{
    public class InscripcionDetalle
    {
        [Key]
        public int InscripcionDetalleId { get; set; }
        public int InscripcionId { get; set; }
        public int AsignaturaId { get; set; }
        public string DescripcionAsignatura { get; set; }
        public int Creditos { get; set; }
        public float SubTotal { get; set; }

        public InscripcionDetalle()
        {
            InscripcionDetalleId = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            DescripcionAsignatura = string.Empty;
            Creditos = 0;
            SubTotal = 0;
        }

        public InscripcionDetalle(int inscripcionDetalleId, int inscripcionId, int asignaturaId, string descripcionAsignatura, int creditos, float subTotal)
        {
            InscripcionDetalleId = inscripcionDetalleId;
            InscripcionId = inscripcionId;
            AsignaturaId = asignaturaId;
            DescripcionAsignatura = descripcionAsignatura;
            Creditos = creditos;
            SubTotal = subTotal;
        }
    }
}
