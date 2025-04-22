using DesafioHexagonal.Aplicacao.Interfaces;

namespace DesafioHexagonal.Infraestrutura.Repositorios
{

	public class UnidadeTrabalho(
		ContextoDados contexto): IUnidadeTrabalho
	{
		public async Task Concluir() => await contexto.SaveChangesAsync();

	}

}
