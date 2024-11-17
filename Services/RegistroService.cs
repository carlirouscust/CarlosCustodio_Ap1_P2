using System.Linq.Expressions;
using CarlosCustodio_Ap1_P2.DAL;
using CarlosCustodio_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P2.Services;

public class RegistroService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int _registroId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Registro
            .AnyAsync(T => T.registroId == _registroId);
    }

    public async Task<bool> Insertar(Registro registro)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Registro.Add(registro);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Registro registro)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Registro.Update(registro);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Registro registro)
    {
        if (!await Existe(registro.registroId))
            return await Insertar(registro);
        else
            return await Modificar(registro);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var Registro = await _context.Registro.
            Where(T => T.registroId == id).ExecuteDeleteAsync();
        return Registro > 0;
    }

    public async Task<Registro?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Registro.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.registroId == id);
    }

    public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Registro.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
