using System.Linq.Expressions;
using CarlosCustodio_Ap1_P2.DAL;
using CarlosCustodio_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P2.Services;

public class combosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int _registroId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.combo
            .AnyAsync(T => T.combosId == _registroId);
    }

    public async Task<bool> Insertar(Combos combos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.combo.Add(combos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Combos combos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.combo.Update(combos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Combos combos)
    {
        if (!await Existe(combos.combosId))
            return await Insertar(combos);
        else
            return await Modificar(combos);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var Registro = await _context.combo.
            Where(T => T.combosId == id).ExecuteDeleteAsync();
        return Registro > 0;
    }

    public async Task<Combos?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.combo.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.combosId == id);
    }

    public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.combo.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
