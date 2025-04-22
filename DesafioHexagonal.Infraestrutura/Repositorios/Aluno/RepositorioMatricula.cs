using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using Microsoft.EntityFrameworkCore;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class RepositorioMatricula(
    ContextoDados contexto) : IRepositorioMatricula
{

    public async Task<MatriculaTDS> Obter(int numero)
    {
        var contato = await contexto.Set<MatriculaTDS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Numero == numero);

        if (contato == null)
            throw new NaoEncontradoException();

        return contato;
    }

    public async Task Inserir(MatriculaTDS matricula)
    {
        await contexto.AddAsync(matricula);
        await contexto.SaveChangesAsync();
    }



    internal static void Configurar(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatriculaTDS>(e =>
        {
            e.ToTable("matricula", "aluno");
        });
    }

}
