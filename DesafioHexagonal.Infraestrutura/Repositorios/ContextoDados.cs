using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class ContextoDados(
    IConfiguration configuracao) : DbContext
{


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuracao.GetConnectionString("dados"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
