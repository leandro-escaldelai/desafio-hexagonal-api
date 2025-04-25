using AutoMapper;
using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using Microsoft.EntityFrameworkCore;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class RepositorioPerfil(
    ContextoDados contexto) : IRepositorioPerfil
{

    public async Task<PerfilTDS?> Obter(int? id)
    {
        return await contexto.Set<PerfilTDS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Inserir(PerfilTDS perfil)
    {
        await contexto.AddAsync(perfil);
        await contexto.SaveChangesAsync();
    }

    public async Task Alterar(PerfilTDS perfil)
    {
        var e = await contexto.AddAsync(perfil);

        e.State = EntityState.Modified;

		await contexto.SaveChangesAsync();
    }



    internal static void Configurar(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PerfilTDS>(e =>
        {
            e.ToTable("Perfil", "Aluno");
            e.Property(e => e.Id)
				.ValueGeneratedOnAdd();
		});
    }

}
