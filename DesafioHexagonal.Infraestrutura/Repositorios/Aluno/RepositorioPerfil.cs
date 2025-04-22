using AutoMapper;
using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using Microsoft.EntityFrameworkCore;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class RepositorioPerfil(
    IMapper mapeador,
    ContextoDados contexto) : IRepositorioPerfil
{

    public async Task<PerfilTDS> Obter(int id)
    {
        var Perfil = await contexto.Set<PerfilTDS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (Perfil == null)
            throw new NaoEncontradoException();

        return Perfil;
    }

    public async Task Inserir(PerfilTDS Perfil)
    {
        await contexto.AddAsync(Perfil);
        await contexto.SaveChangesAsync();
    }

    public async Task Alterar(PerfilTDS Perfil)
    {
        var PerfilNovo = await contexto.Set<PerfilTDS>()
            .FirstOrDefaultAsync(e => e.Id == Perfil.Id);

        if (PerfilNovo == null)
            throw new NaoEncontradoException();

        mapeador.Map(Perfil, PerfilNovo);

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
