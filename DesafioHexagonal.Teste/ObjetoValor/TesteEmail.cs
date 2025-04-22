using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio.ObjetoValor;

public class TesteEmail : TesteBase
{

	[Fact]
	public void Classe_Existe()
	{
		Assembly
			.Load("DesafioHexagonal.Dominio")
			.GetType("DesafioHexagonal.Dominio.ObjetoValor.Email")
			.Should()
			.NotBeNull();
	}

	[Fact]
	public void Criar_Email()
	{
		var referencia = new { Url = gerador.Internet.Email() };

		var email = ConstrutorEmail.Criar()
			.ComUrl(referencia.Url)
			.Construir();

		email.Should().BeEquivalentTo(referencia);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("email")]
	[InlineData("@missingusername.com")]
	[InlineData("username@.com")]
	[InlineData("username@com")]
	[InlineData("username@domain,com")]
	public void Criar_Email_Invalido(string? valor)
	{
		var email = ConstrutorEmail.Criar()
			.ComUrl(valor);

		email.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}
