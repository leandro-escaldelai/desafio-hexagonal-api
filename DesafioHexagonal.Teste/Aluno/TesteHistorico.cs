using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;

public class TesteHistorico : TesteBase
{

	[Fact]
	public void Classe_Existe()
	{
		Assembly
			.Load("DesafioHexagonal.Dominio")
			.GetType("DesafioHexagonal.Dominio.Entidades.Historico")
			.Should()
			.NotBeNull();
	}

	[Fact]
	public void Criar_Historico()
	{
		var termino = gerador.Date.Past(3, DateTime.Now);
		var inicio = termino.AddMonths(-gerador.Random.Int(12, 48));

		var referencia = new
		{
			Id = gerador.Random.Int(1),
			Perfil = ConstrutorPerfil.CriarAleatorio(),
			Instituicao = gerador.Lorem.Sentence(),
			Curso = gerador.Lorem.Sentence(),
			Situacao = ConstrutorSituacaoHistorico.CriarAleatorio(),
			DataInicio = inicio,
			DataTermino = termino,
			Descricao = gerador.Lorem.Sentence(),
			UrlArquivo = gerador.Internet.Url()
		};

		var testavel = ConstrutorHistorico.Criar()
			.ComId(referencia.Id)
			.ComPerfil(referencia.Perfil)
			.ComInstituicao(referencia.Instituicao)
			.ComCurso(referencia.Curso)
			.ComSituacao(referencia.Situacao)
			.ComDataInicio(referencia.DataInicio)
			.ComDataTermino(referencia.DataTermino)
			.ComDescricao(referencia.Descricao)
			.ComUrlArquivo(referencia.UrlArquivo)
			.Construir();

		testavel.Should().BeEquivalentTo(referencia);
	}

	[Fact]
	public void Criar_Historico_Sem_Perfil()
	{
		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComPerfil(ConstrutorPerfil.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Criar_Historico_Com_Instituicao_Invalida(string? valor)
	{
		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComInstituicao(valor);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Criar_Historico_Com_Curso_Invalido(string? valor)
	{
		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComCurso(valor);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Historico_Sem_Situacao()
	{
		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComSituacao(ConstrutorSituacaoHistorico.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	public void Criar_Historico_Com_DataInicio_Invalida(string? valor)
	{
		DateTime? data = valor != null
			? DateTime.Parse(valor)
			: null;

		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComDataInicio(data);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("2090-01-01")]
	public void Criar_Historico_Com_DataTermino_Invalida(string? valor)
	{
		DateTime? data = valor != null
			? DateTime.Parse(valor)
			: null;

		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComDataTermino(data);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Historico_Com_DataInicio_Maior_Que_DataTermino()
	{
		var testavel = ConstrutorHistorico.Criar()
			.Aleatorio()
			.ComDataTermino(DateTime.Now.AddDays(-50))
			.ComDataInicio(DateTime.Now);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}

