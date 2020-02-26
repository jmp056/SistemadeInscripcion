using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea4_SistemadeInscripcion.Models
{
    public class Asignaturas
    {
        [Key]
        public int  AsignaturaId{ get; set; }
        [Required(ErrorMessage = "El codigo no puede estar vacio!..")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La descripcion no puede estar vacia!..")]
        public string Descripcion { get; set; }
        public string PreRequisito { get; set; }
        [Range(minimum: 1, maximum: 7, ErrorMessage = "La cantidad de creditos debe estar entre 1 y 7!...")]
        public int Creditos { get; set; }

        public Asignaturas()
        {
            AsignaturaId = 0;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            PreRequisito = string.Empty;
            Creditos = 0;
        }
    }
}
