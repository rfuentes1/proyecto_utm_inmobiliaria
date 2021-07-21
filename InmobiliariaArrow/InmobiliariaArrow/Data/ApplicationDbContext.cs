using InmobiliariaArrow.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaArrow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //por cada clase entidad (las que estan en la carpeta entities) se tiene que agregr
        //una propiedad aquí de ese tipo
        public virtual DbSet<Inmueble> Inmuebles { get; set; }
        public virtual DbSet<TipoPropiedad> TipoPropiedad { get; set; }

    }
}
