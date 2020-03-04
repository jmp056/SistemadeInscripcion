using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea4_SistemadeInscripcion.Models
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "La inscripcion debe tener asignado un estudiante!...")]
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El semestre no puede estar vacio!..")]
        public string Semestre { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 100, ErrorMessage = "El limine de creditos debe estar comprendido entre 1 y 100!...")]
        public int Limite { get; set; }
        [ForeignKey("InscripcionId")]
        public List<InscripcionDetalle> DetalleAsignaturas { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 100, ErrorMessage = "Los creditos tomados deben estar comprendidos entre 1 y la cantidad de creditos disponibles!...")]
        public int Tomados { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Los creditos tomados no pueden ser mayores a 100 o a la cantidad de creditos limite!...")]
        public int Disponibles { get; set; }

        public int Monto { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            Semestre = string.Empty;
            EstudianteId = 0;
            Limite = 0;
            Tomados = 0;
            Disponibles = 0;
            Monto = 0;
        }
    }
}
