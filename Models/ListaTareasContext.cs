using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ListaTareas.Models
{
    public partial class ListaTareasContext : DbContext
    {
        public ListaTareasContext()
        {
        }

        public ListaTareasContext(DbContextOptions<ListaTareasContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Tarea> Tareas { get; set; }

        
    }
}
