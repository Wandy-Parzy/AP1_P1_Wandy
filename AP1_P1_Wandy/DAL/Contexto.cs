using Microsoft.EntityFrameworkCore;
using AP1_P1_Wandy.Models;

namespace AP1_P1_Wandy.DAL{
public class Contexto : DbContext
{
    public DbSet<Aportes> Aportes { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

}
}