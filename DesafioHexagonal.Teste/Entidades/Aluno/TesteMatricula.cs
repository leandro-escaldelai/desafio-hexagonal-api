using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;

public class TesteMatricula : TesteBase
{

    [Fact]
    public void Classe_Existe()
    {
        Assembly
            .Load("DesafioHexagonal.Dominio")
            .GetType("DesafioHexagonal.Dominio.Entidades.Matricula")
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void Criar_Matricula()
    {
        var referencia = new
        {
            Perfil = ConstrutorPerfil.CriarAleatorio(),
            Numero = gerador.Random.Int(1, 1000000),
			Data = gerador.Date.Past(3, DateTime.Now)
		};

        var testavel = ConstrutorMatricula.Criar()
            .ComPerfil(referencia.Perfil)
            .ComNumero(referencia.Numero)
            .ComData(referencia.Data)
            .Construir();

		testavel.Should().BeEquivalentTo(referencia);
	}

	[Fact]
	public void Criar_Matricula_Sem_Perfil()
	{
		var testavel = ConstrutorMatricula.Criar()
			.Aleatorio()
			.ComPerfil(ConstrutorPerfil.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

    [Theory]
	[InlineData(null)]
	[InlineData(0)]
	[InlineData(-1)]
    public void Criar_Matricula_Com_Numero_Invalido(int? numero)
    {
		var testavel = ConstrutorMatricula.Criar()
			.Aleatorio()
			.ComNumero(numero);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

    [Theory]
	[InlineData(null)]
	[InlineData("2090-01-01")]
    public void Criar_Matricula_Com_Data_Invalida(string? valor)
    {
		var data = ObterData(valor);

		var testavel = ConstrutorMatricula.Criar()
			.Aleatorio()
			.ComData(data);

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

}
