using DesafioHexagonal.Dominio.Entidades;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorHistorico
{

	private int? id;

	private Perfil? perfil;

	private string? instituicao;

	private string? curso;

	private SituacaoHistorico? situacao;

	private DateTime? dataInicio;

	private DateTime? dataTermino;

	private string? descricao;

	private string? urlArquivo;


	private ConstrutorHistorico() { }

	public static ConstrutorHistorico Criar()
	{
		return new ConstrutorHistorico();
	}

	public static Historico CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Historico? CriarNulo()
	{
		return null;
	}



	public ConstrutorHistorico ComId(int? id)
	{
		this.id = id;
		return this;
	}

	public ConstrutorHistorico ComPerfil(Perfil? perfil)
	{
		this.perfil = perfil;
		return this;
	}

	public ConstrutorHistorico ComInstituicao(string? instituicao)
	{
		this.instituicao = instituicao;
		return this;
	}

	public ConstrutorHistorico ComCurso(string? curso)
	{
		this.curso = curso;
		return this;
	}

	public ConstrutorHistorico ComSituacao(SituacaoHistorico? situacao)
	{
		this.situacao = situacao;
		return this;
	}

	public ConstrutorHistorico ComDataInicio(DateTime? dataInicio)
	{
		this.dataInicio = dataInicio;
		return this;
	}

	public ConstrutorHistorico ComDataTermino(DateTime? dataTermino)
	{
		this.dataTermino = dataTermino;
		return this;
	}

	public ConstrutorHistorico ComDescricao(string? descricao)
	{
		this.descricao = descricao;
		return this;
	}

	public ConstrutorHistorico ComUrlArquivo(string? urlArquivo)
	{
		this.urlArquivo = urlArquivo;
		return this;
	}

	public ConstrutorHistorico Aleatorio()
	{
		var gerador = new Bogus.Faker();

		ComPerfil(ConstrutorPerfil.CriarAleatorio());
		ComInstituicao(gerador.Lorem.Sentence());
		ComCurso(gerador.Lorem.Sentence());
		ComSituacao(ConstrutorSituacaoHistorico.CriarAleatorio());
		ComDataTermino(gerador.Date.Past(3, DateTime.Now));
		ComDataInicio(dataTermino!.Value.AddMonths(-gerador.Random.Int(12, 48)));
		ComDescricao(gerador.Lorem.Sentence());
		ComUrlArquivo(gerador.Internet.Url());

		return this;
	}



	public Historico Construir()
	{
		var historico = new Historico(perfil, instituicao, curso, situacao, dataInicio, dataTermino, descricao, urlArquivo);

		if (id.HasValue)
			historico.GetType().GetProperty("Id")?.SetValue(historico, id);

		return historico;
	}

}
