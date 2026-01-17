
using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.DAL;
using RegistroEstudiantes.Models;
using System.Linq.Expressions;

namespace RegistroEstudiantes.Services
{
    public class EstudiantesService(IDbContextFactory<Contexto> DbFactory)
    {

        // MÉTODO GUARDAR
        public async Task<bool> Guardar(Estudiantes estudiante)
        {
            if (!await Existe(estudiante.EstudianteId))
                return await Insertar(estudiante);
            else
                return await Modificar(estudiante);
        }

        // MÉTODO EXISTE
        private async Task<bool> Existe(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes
                .AnyAsync(e => e.EstudianteId == estudianteId);
        }

        // MÉTODO INSERTAR
        private async Task<bool> Insertar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Add(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }

        // MÉTODO MODIFICAR
        private async Task<bool> Modificar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }

   
        // MÉTODO BUSCAR
        public async Task<Estudiantes?> Buscar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
        }

        // MÉTODO ELIMINAR
        public async Task<bool> Eliminar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes
                .AsNoTracking()
                .Where(e => e.EstudianteId == estudianteId)
                .ExecuteDeleteAsync() > 0;
        }

        // MÉTODO LISTAR
        public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

