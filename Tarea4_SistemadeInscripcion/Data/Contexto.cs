﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea4_SistemadeInscripcion.Models;

namespace Tarea4_SistemadeInscripcion.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<InscripcionDetalle> InscripcionDetalles { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database/Inscripciones.Db");
        }
    }
}
