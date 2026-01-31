using RegistroEstudiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroEstudiantes.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Estudiantes> Estudiantes { get; set; }
}