using AutoMapper;
using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using Microsoft.EntityFrameworkCore;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class RepositorioHistorico(
	IMapper mapeador,
	ContextoDados contexto) : IRepositorioHistorico
{

	public async Task<HistoricoTDS> Obter(int id)
	{
		var Historico = await contexto.Set<HistoricoTDS>()
			.AsNoTracking()
			.FirstOrDefaultAsync(e => e.Id == id);

		if (Historico == null)
			throw new NaoEncontradoException();
		return Historico;
	}

	public async Task<IEnumerable<HistoricoTDS>> ObterLista(int idPerfil)
	{
		return await contexto.Set<HistoricoTDS>()
			.AsNoTracking()
			.Where(e => e.IdPerfil == idPerfil)
			.ToArrayAsync();
	}

	public async Task Inserir(HistoricoTDS historico)
	{
		await contexto.AddAsync(historico);
		await contexto.SaveChangesAsync();
	}

	public async Task Alterar(HistoricoTDS historico)
	{
		var historicoNovo = await contexto.Set<HistoricoTDS>()
			.FirstOrDefaultAsync(e => e.Id == historico.Id);

		if (historicoNovo == null)
			throw new NaoEncontradoException();

		mapeador.Map(historico, historicoNovo);

		await contexto.SaveChangesAsync();
	}


	internal static void Configurar(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricoTDS>(e =>
        {
            e.ToTable("historico", "aluno");
            e.HasKey(e => e.Id);
            e.Property(e => e.Id)
                .ValueGeneratedOnAdd();
		});
    }

}
