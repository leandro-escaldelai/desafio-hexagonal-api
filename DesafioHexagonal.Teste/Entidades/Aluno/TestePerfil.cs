using DesafioHexagonal.Dominio.Excecoes;
using DesafioHexagonal.Dominio.ObjetoValor;
using DesafioHexagonal.Teste.Dominio.Construtores;
using FluentAssertions;
using System.Drawing;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;

public class TestePerfil : TesteBase
{

    [Fact]
    public void Classe_Existe()
    {
        Assembly
            .Load("DesafioHexagonal.Dominio")
            .GetType("DesafioHexagonal.Dominio.Entidades.Perfil")
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void Criar_Perfil()
    {
		var referencia = new
		{
			Id = gerador.Random.Int(1),
			Nome = gerador.Name.FullName(),
			Endereco = gerador.Address.FullAddress(),
			Telefone = ConstrutorTelefone.CriarAleatorio(),
			Email = ConstrutorEmail.CriarAleatorio(),
			Foto = gerador.Internet.Url()
		};

		var testavel = ConstrutorPerfil.Criar()
			.ComId(referencia.Id)
			.ComNome(referencia.Nome)
			.ComEndereco(referencia.Endereco)
			.ComTelefone(referencia.Telefone)
			.ComEmail(referencia.Email)
			.ComFoto(referencia.Foto)
			.Construir();

		testavel.Should().BeEquivalentTo(referencia);
	}

    [Theory]
	[InlineData(null)]
	[InlineData("")]
    public void Criar_Perfil_Nome_Invalido(string? valor)
    {
		var testavel = ConstrutorPerfil.Criar()
			.Aleatorio()
			.ComNome(valor);
			
		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

    [Theory]
	[InlineData(null)]
	[InlineData("")]
    public void Criar_Perfil_Endereco_Invalido(string? valor)
    {
		var testavel = ConstrutorPerfil.Criar()
			.Aleatorio()
			.ComEndereco(valor);
			
		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Perfil_Sem_Telefone()
	{
		var testavel = ConstrutorPerfil.Criar()
			.Aleatorio()
			.ComTelefone(ConstrutorTelefone.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Criar_Perfil_Sem_Email()
	{
		var testavel = ConstrutorPerfil.Criar()
			.Aleatorio()
			.ComEmail(ConstrutorEmail.CriarNulo());

		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("url invalida")]
    public void Criar_Perfil_Foto_Invalida(string? valor)
    {
		var testavel = ConstrutorPerfil.Criar()
			.Aleatorio()
			.ComFoto(valor);
			
		testavel.Invoking(x => x.Construir())
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Atualizar_Perfil()
	{
		var referencia = new
		{
			Id = gerador.Random.Int(1),
			Nome = gerador.Name.FullName(),
			Endereco = gerador.Address.FullAddress(),
			Telefone = ConstrutorTelefone.CriarAleatorio(),
			Email = ConstrutorEmail.CriarAleatorio(),
			Foto = gerador.Internet.Url()
		};
		var testavel = ConstrutorPerfil.Criar()
			.Aleatorio()
			.ComId(referencia.Id)
			.Construir();

		testavel.Atualizar(
			referencia.Nome,
			referencia.Endereco,
			referencia.Telefone,
			referencia.Email,
			referencia.Foto
		);

		testavel.Should().BeEquivalentTo(referencia);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Atualizar_Perfil_Nome_Invalido(string? valor)
	{
		var testavel = ConstrutorPerfil.CriarAleatorio();

		testavel.Invoking(x => x.Atualizar(valor, x.Endereco, x.Telefone, x.Email, x.Foto))
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Atualizar_Perfil_Endereco_Invalido(string? valor)
	{
		var testavel = ConstrutorPerfil.CriarAleatorio();

		testavel.Invoking(x => x.Atualizar(x.Nome, valor, x.Telefone, x.Email, x.Foto))
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Atualizar_Perfil_Sem_Telefone()
	{
		var testavel = ConstrutorPerfil.CriarAleatorio();

		testavel.Invoking(x => x.Atualizar(x.Nome, x.Endereco, null, x.Email, x.Foto))
			.Should()
			.Throw<ValidacaoException>();
	}

	[Fact]
	public void Atualizar_Perfil_Sem_Email()
	{
		var testavel = ConstrutorPerfil.CriarAleatorio();

		testavel.Invoking(x => x.Atualizar(x.Nome, x.Endereco, x.Telefone, null, x.Foto))
			.Should()
			.Throw<ValidacaoException>();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("url invalida")]
	public void Atualizar_Perfil_Foto_Invalida(string? valor)
	{
		var testavel = ConstrutorPerfil.CriarAleatorio();

		testavel.Invoking(x => x.Atualizar(x.Nome, x.Endereco, x.Telefone, x.Email, valor))
			.Should()
			.Throw<ValidacaoException>();
	}

}
