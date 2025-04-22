using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;


public class TesteContato : TesteBase
{

    [Fact]
    public void Classe_Existe()
    {
        Assembly
            .Load("DesafioHexagonal.Dominio")
            .GetType("DesafioHexagonal.Dominio.Entidades.Contato")
            .Should()
            .NotBeNull();
    }

	[Fact]
	public void Criar_Contato()
	{
		var referencia = new
		{
			Id = gerador.Random.Int(1),
			Nome = gerador.Name.FullName(),
			Perfil = ConstrutorPerfil.CriarAleatorio(),
			Telefone = ConstrutorTelefone.CriarAleatorio(),
			Email = ConstrutorEmail.CriarAleatorio()
		};

		var testavel = ConstrutorContato.Criar()
			.ComId(referencia.Id)
			.ComNome(referencia.Nome)
			.ComPerfil(referencia.Perfil)
			.ComTelefone(referencia.Telefone)
			.ComEmail(referencia.Email)
			.Construir();

		testavel.Should().BeEquivalentTo(referencia);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Criar_Contato_Nome_Invalido(string? valor)
	{
		var testavel = ConstrutorContato.Criar()
			.Aleatorio()
			.ComNome(valor);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Contato_Sem_Perfil()
	{
		var testavel = ConstrutorContato.Criar()
			.Aleatorio()
			.ComPerfil(ConstrutorPerfil.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Contato_Sem_Telefone()
	{
		var testavel = ConstrutorContato.Criar()
			.Aleatorio()
			.ComTelefone(ConstrutorTelefone.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Contato_Sem_Email()
	{
		var testavel = ConstrutorContato.Criar()
			.Aleatorio()
			.ComEmail(ConstrutorEmail.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}
