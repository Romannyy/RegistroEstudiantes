using Microsoft.EntityFrameworkCore;
using RegistroTiposPuntos.DAL;
using System.Linq.Expressions;
using RegistroTiposPuntos.Models;

namespace RegistroTiposPuntos.Services
{
    public class TiposPuntosService(IDbContextFactory<Contexto> DbFactory)
    {
        // MÉTODO INSERTAR
        private async Task<bool> Insertar(TiposPuntos tipo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.TiposPuntos.Add(tipo);
            return await contexto.SaveChangesAsync() > 0;
        }

        // MÉTODO EXISTE POR ID
        private async Task<bool> Existe(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos
                .AnyAsync(t => t.TipoId == tipoId);
        }

        // MÉTODO MODIFICAR
        private async Task<bool> Modificar(TiposPuntos tipo)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(tipo);
            return await contexto.SaveChangesAsync() > 0;
        }

        // MÉTODO EXISTE POR NOMBRE
        private async Task<bool> ExisteNombre(string nombre, int tipoId = 0)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos
                .AnyAsync(t =>
                    t.Nombre == nombre &&
                    t.TipoId != tipoId);
        }

        // MÉTODO BUSCAR
        public async Task<TiposPuntos?> Buscar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == tipoId);
        }

        // MÉTODO ELIMINAR
        public async Task<bool> Eliminar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos
                .Where(t => t.TipoId == tipoId)
                .ExecuteDeleteAsync() > 0;
        }

        // MÉTODO GUARDAR
        public async Task<bool> Guardar(TiposPuntos tipo)
        {
            // Validación de nombre duplicado
            if (await ExisteNombre(tipo.Nombre, tipo.TipoId))
                throw new Exception("No se permite registrar dos tipos de puntos con el mismo nombre.");

            if (!await Existe(tipo.TipoId))
                return await Insertar(tipo);
            else
                return await Modificar(tipo);
        }

        // MÉTODO LISTAR
        public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
