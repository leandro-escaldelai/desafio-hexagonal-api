using AutoMapper;
using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using Microsoft.EntityFrameworkCore;

namespace DesafioHexagonal.Infraestrutura.Repositorios;

public class RepositorioNota(
	IMapper mapeador,
	ContextoDados contexto) : IRepositorioNota
{


	public async Task<NotaTDS> Obter(int id)
	{
		var nota = await contexto.Set<NotaTDS>()
			.AsNoTracking()
			.FirstOrDefaultAsync(e => e.Id == id);

		if (nota == null)
			throw new NaoEncontradoException();
		return nota;
	}

	public async Task<IEnumerable<NotaTDS>> ObterLista(int idPerfil)
	{
		return await contexto.Set<NotaTDS>()
			.AsNoTracking()
			.Where(e => e.IdPerfil == idPerfil)
			.ToArrayAsync();
	}

	public async Task Inserir(NotaTDS nota)
	{
		await contexto.AddAsync(nota);
		await contexto.SaveChangesAsync();
	}

	public async Task Alterar(NotaTDS nota)
	{
		var notaNovo = await contexto.Set<NotaTDS>()
			.FirstOrDefaultAsync(e => e.Id == nota.Id);

		if (notaNovo == null)
			throw new NaoEncontradoException();

		mapeador.Map(nota, notaNovo);

		await contexto.SaveChangesAsync();
	}


	internal static void Configurar(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotaTDS>(e =>
        {
            e.ToTable("nota", "aluno");
        });
    }

}
