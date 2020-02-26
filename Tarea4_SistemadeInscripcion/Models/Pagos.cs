﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea4_SistemadeInscripcion.Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "El pago debe tener asignado una inscripcion!...")]
        public int InscripcionId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "El monto pagado debe ser mayor a 0!...")]
        public float Monto { get; set; }

        public Pagos()
        {
            PagoId = 0;
            Fecha = DateTime.Now;
            InscripcionId = 0;
            Monto = 0;
        }
    }
}
