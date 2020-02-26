using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea4_SistemadeInscripcion.Models
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "La matricula no puede estar vacia!..")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "El nombre no puede estar vacia!..")]
        public string Nombres { get; set; }
        public float Balance { get; set; }

        public Estudiantes()
        {
            EstudianteId = 0;
            Matricula = string.Empty;
            Nombres = string.Empty;
            Balance = 0;
        }
    }
}
