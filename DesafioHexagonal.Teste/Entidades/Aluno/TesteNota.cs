using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;

public class TesteNota : TesteBase
{

    [Fact]
    public void Classe_Existe()
    {
        Assembly
            .Load("DesafioHexagonal.Dominio")
            .GetType("DesafioHexagonal.Dominio.Entidades.Nota")
            .Should()
            .NotBeNull();
    }

	[Fact]
	public void Criar_Nota()
	{
		var referencia = new
		{
			Id = gerador.Random.Int(1, 1000),
			Perfil = ConstrutorPerfil.CriarAleatorio(),
			Professor = ConstrutorProfessor.CriarAleatorio(),
			Aula = ConstrutorAula.CriarAleatorio(),
			Valor = gerador.Random.Decimal(0, 10)
		};

		var testavel = ConstrutorNota.Criar()
			.ComId(referencia.Id)
			.ComPerfil(referencia.Perfil)
			.ComProfessor(referencia.Professor)
			.ComAula(referencia.Aula)
			.ComValor(referencia.Valor)
			.Construir();

		testavel.Should().BeEquivalentTo(referencia);
	}

	[Fact]
	public void Criar_Nota_Sem_Perfil()
	{
		var testavel = ConstrutorNota.Criar()
			.Aleatorio()
			.ComPerfil(ConstrutorPerfil.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Nota_Sem_Professor()
	{
		var testavel = ConstrutorNota.Criar()
			.Aleatorio()
			.ComProfessor(ConstrutorProfessor.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Nota_Sem_Aula()
	{
		var testavel = ConstrutorNota.Criar()
			.Aleatorio()
			.ComAula(ConstrutorAula.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData(-1.0)]
	public void Criar_Nota_Com_Valor_Invalido(double? valor)
	{
		var testavel = ConstrutorNota.Criar()
			.Aleatorio()
			.ComValor((decimal?)valor);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}
