using Microsoft.EntityFrameworkCore;

namespace CarlosCustodio_Ap1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }

}
