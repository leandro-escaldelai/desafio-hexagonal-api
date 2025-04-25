using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;

public class TesteTelefone : TesteBase
{

	[Fact]
	public void Classe_Existe()
	{
		Assembly
			.Load("DesafioHexagonal.Dominio")
			.GetType("DesafioHexagonal.Dominio.ObjetoValor.Telefone")
			.Should()
			.NotBeNull();
	}

	[Fact]
	public void Criar_Telefone()
	{
		var ddd = gerador.GerarTelefoneDdd();
		var numero = gerador.GerarTelefoneNumero();
		var referencia = new { Numero = $"({ddd}) {numero}" };

		var telefone = ConstrutorTelefone.Criar()
			.ComDdd(ddd)
			.ComNumero(numero)
			.Construir();

		telefone.Should().BeEquivalentTo(referencia);
	}

	[Fact]
	public void Criar_Celular()
	{
		var ddd = gerador.GerarTelefoneDdd();
		var numero = gerador.GerarTelefoneNumero();
		var referencia = new { Numero = $"({ddd}) {numero}" };

		var telefone = ConstrutorTelefone.Criar()
			.ComDdd(ddd)
			.ComNumero(numero)
			.Construir();

		telefone.Should().BeEquivalentTo(referencia);
	}

	[Theory]
	[InlineData(null), InlineData(""), InlineData(" "), InlineData(".")]
	[InlineData("3"), InlineData("00"), InlineData("58"), InlineData("XX")]
	[InlineData("2X"), InlineData("X2"), InlineData("115")]
	public void Criar_Telefone_Ddd_Invalido(string? valor)
	{
		var telefone = ConstrutorTelefone.Criar()
			.Aleatorio()
			.ComDdd(valor);

		telefone.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null), InlineData(""), InlineData(" "), InlineData("9")]
	[InlineData("99999999"), InlineData("999999999"), InlineData("99999-99999")]
	[InlineData("9999-99999"), InlineData("XXXX-XXXX")]
	public void Criar_Telefone_Numero_Invalido(string? valor)
	{
		var telefone = ConstrutorTelefone.Criar()
			.Aleatorio()
			.ComDdd(valor);

		telefone.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}
