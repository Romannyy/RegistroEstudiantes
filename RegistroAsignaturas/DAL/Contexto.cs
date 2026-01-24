using Microsoft.EntityFrameworkCore;
using RegistroAsignaturas.Models;

namespace RegistroAsignaturas.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Asignaturas> Asignaturas { get; set; }
    }
}
