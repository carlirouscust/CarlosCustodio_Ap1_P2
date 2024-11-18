using CarlosCustodio_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }

    public DbSet<Combos> combo { get; set; }
    public DbSet<ArticulosC> ArticulosC { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ArticulosC>().HasData(new List<ArticulosC>()
        {
            new ArticulosC
            {
                articuloId = 1,
                descripcion = "RAM Corsair 16GB",
                costo = 2500.00m,
                precio = 5000.00m,
                existencia = 100
            },
            new ArticulosC
            {
                articuloId = 2,
                descripcion = "Disco Duro HP 524GB",
                costo = 1500.00m,
                precio = 3000.00m,
                existencia = 100
            },
            new ArticulosC
            {
                articuloId = 3,
                descripcion = "Intel i7 11va Gen",
                costo = 15000.00m,
                precio = 35000.00m,
                existencia = 100
            },
            new ArticulosC
            {
                articuloId = 4,
                descripcion = "Power Suply Corsair",
                costo = 3000.00m,
                precio = 5000.00m,
                existencia = 100
            }

        });
    }
}
