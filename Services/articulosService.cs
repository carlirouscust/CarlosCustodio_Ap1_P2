using CarlosCustodio_Ap1_P2.Models;
using System.Linq.Expressions;
using CarlosCustodio_Ap1_P2.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P2.Services;

public class articulosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<ArticulosC>> ListarArticulos()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.ArticulosC
            .AsNoTracking()
        .ToListAsync();
    }


    public async Task<ArticulosC?> ObtenerArticuloPorId(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.ArticulosC
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.articuloId == id);
    }


    public async Task ActualizarExistencia(int articuloId, decimal cantidad)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var articulo = await _contexto.ArticulosC.FindAsync(articuloId);
        if (articulo != null)
        {
            articulo.existencia -= cantidad;
            _contexto.ArticulosC.Update(articulo);
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task AgregarCantidad(int articuloId, int cantidad)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var articulo = await _contexto.ArticulosC.FindAsync(articuloId);

        if (articulo != null)
        {

            articulo.existencia += cantidad;


            await _contexto.SaveChangesAsync();
        }
    }
}
