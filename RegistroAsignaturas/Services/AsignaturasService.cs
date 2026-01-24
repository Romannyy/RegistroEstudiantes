using Microsoft.EntityFrameworkCore;
using RegistroAsignaturas.DAL;
using System.Linq.Expressions;
using RegistroAsignaturas.Models;

namespace RegistroAsignaturas.Services
{

    public class AsignaturasService(IDbContextFactory<Contexto> DbFactory)
    {

        // MÉTODO GUARDAR
        public async Task<bool> Guardar(Asignaturas asignatura)
        {
            // Validación de nombre duplicado
            if (await ExisteNombre(asignatura.Nombre, asignatura.AsignaturaId))
                throw new Exception("No se puede registrar dos estudiantes con el mismo nombre.");

            if (!await Existe(asignatura.AsignaturaId))
                return await Insertar(asignatura);
            else
                return await Modificar(asignatura);
        }

        // MÉTODO EXISTE POR ID
        private async Task<bool> Existe(int asignaturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas
                .AnyAsync(e => e.AsignaturaId == asignaturaId);
        }

        // MÉTODO EXISTE POR NOMBRE 
        private async Task<bool> ExisteNombre(string nombre, int asignaturaId = 0)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas
                .AnyAsync(e =>
                    e.Nombre == nombre &&
                    e.AsignaturaId != asignaturaId);
        }

        // MÉTODO INSERTAR
        private async Task<bool> Insertar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Asignaturas.Add(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }

        // MÉTODO MODIFICAR
        private async Task<bool> Modificar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }

        // MÉTODO BUSCAR
        public async Task<Asignaturas?> Buscar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.AsignaturaId == estudianteId);
        }

        // MÉTODO ELIMINAR
        public async Task<bool> Eliminar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas
                .Where(e => e.AsignaturaId == estudianteId)
                .ExecuteDeleteAsync() > 0;
        }

        // MÉTODO LISTAR
        public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

