using DesafioHexagonal.Dominio.ObjetoValor;
using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.Entidades
{
	public class Historico
	{

		public int? Id { get; private set; }

		public Perfil? Perfil { get; private set; }

		public string? Instituicao { get; private set; }

		public string? Curso { get; private set; }

		public SituacaoHistorico? Situacao { get; private set; }

		public DateTime? DataInicio { get; private set; }

		public DateTime? DataTermino { get; private set; }

		public string? Descricao { get; private set; }

		public string? UrlArquivo { get; private set; }



		private Historico() { }

		public Historico(Perfil? perfil, string? instituicao, string? curso, SituacaoHistorico? situacao, DateTime? dataInicio, DateTime? dataTermino, string? descricao, string? urlArquivo)
		{
			Validador.Criar()
				.ObjetoNulo(perfil, "Perfil")
				.TextoNuloOuVazio(instituicao, "Instituição")
				.TextoNuloOuVazio(curso, "Curso")
				.ObjetoNulo(situacao, "Situação")
				.DataInicioFim(dataInicio, dataTermino, "de Início", "de Término")
				.DataFuturaProibida(dataTermino, "de Término")
				.Url(urlArquivo, "Url do Arquivo")
				.Validar();

			Perfil = perfil;
			Instituicao = instituicao;
			Curso = curso;
			Situacao = situacao;
			DataInicio = dataInicio;
			DataTermino = dataTermino;
			Descricao = descricao;
			UrlArquivo = urlArquivo;
		}

	}

}
