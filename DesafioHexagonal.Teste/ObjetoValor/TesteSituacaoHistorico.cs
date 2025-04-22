using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio.ObjetoValor;

public class TesteSituacaoHistorico : TesteBase
{

	[Fact]
	public void Classe_Existe()
	{
		Assembly
			.Load("DesafioHexagonal.Dominio")
			.GetType("DesafioHexagonal.Dominio.ObjetoValor.SituacaoHistorico")
			.Should()
			.NotBeNull();
	}


	[Fact]
	public void Criar_SituacaoHistorico()
	{
		var referencia = new { Status = gerador.GerarSituacaoHistorico() };

		var email = ConstrutorSituacaoHistorico.Criar()
			.ComSituacao(referencia.Status)
			.Construir();

		email.Should().BeEquivalentTo(referencia);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("situacao invalida")]
	public void Criar_SituacaoHistorico_Invalido(string? valor)
	{
		var email = ConstrutorSituacaoHistorico.Criar()
			.ComSituacao(valor);

		email.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}
