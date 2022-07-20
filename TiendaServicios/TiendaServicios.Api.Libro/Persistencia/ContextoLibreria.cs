using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria() { }

        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }

        //Se le asigna la propiedad virtual para que permita que el objeto se pueda sobreescribir a futuro
        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
