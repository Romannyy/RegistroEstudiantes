using Microsoft.EntityFrameworkCore;
using RegistroTiposPuntos.Models;

namespace RegistroTiposPuntos.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }
        public DbSet<TiposPuntos> TiposPuntos { get; set; }
    }

}

