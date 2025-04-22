using AutoMapper;
using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using Microsoft.EntityFrameworkCore;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class RepositorioContato (
    IMapper mapeador,
    ContextoDados contexto): IRepositorioContato
{

    public async Task<ContatoTDS> Obter(int id)
    {
        var contato = await contexto.Set<ContatoTDS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (contato == null)
            throw new NaoEncontradoException();

        return contato;
    }

    public async Task<IEnumerable<ContatoTDS>> ObterLista(int idPerfil)
    {
        return await contexto.Set<ContatoTDS>()
            .AsNoTracking()
            .Where(e => e.IdPerfil == idPerfil)
            .ToArrayAsync();
    }

    public async Task Inserir(ContatoTDS contato)
    {
        await contexto.AddAsync(contato);
        await contexto.SaveChangesAsync();
    }

    public async Task Alterar(ContatoTDS contato)
    {
        var contatoNovo = await contexto.Set<ContatoTDS>()
            .FirstOrDefaultAsync(e => e.Id == contato.Id);

        if (contatoNovo == null)
            throw new NaoEncontradoException();

        mapeador.Map(contato, contatoNovo);

        await contexto.SaveChangesAsync();
    }



    internal static void Configurar(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContatoTDS>(e =>
        {
            e.ToTable("contato", "aluno");
            e.HasKey(e => e.Id);
            e.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        });
    }

}
