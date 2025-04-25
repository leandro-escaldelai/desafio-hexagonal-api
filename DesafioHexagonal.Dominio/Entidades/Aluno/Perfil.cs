using DesafioHexagonal.Dominio.ObjetoValor;
using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.Entidades;

public class Perfil
{

	public int? Id { get; private set; }

	public string? Nome { get; private set; }

	public string? Endereco { get; private set; }

	public Telefone? Telefone { get; private set; }

	public Email? Email { get; private set; }

	public string? Foto { get; private set; }


	private Perfil() { }

	public Perfil(string? nome, string? endereco, Telefone? telefone, Email? email, string? foto)
	{
		Validador.Criar()
			.TextoNuloOuVazio(nome, nameof(Nome))
			.TextoNuloOuVazio(endereco, "Endereço")
			.ObjetoNulo(telefone, nameof(Telefone))
			.ObjetoNulo(email, "e-mail")
			.Url(foto, nameof(Foto))
			.Validar();

		Nome = nome;
		Endereco = endereco;
		Telefone = telefone;
		Email = email;
		Foto = foto;
	}


	public void Atualizar(string? nome, string? endereco, Telefone? telefone, Email? email, string? foto)
	{
		Validador.Criar()
			.TextoNuloOuVazio(nome, nameof(Nome))
			.TextoNuloOuVazio(endereco, "Endereço")
			.ObjetoNulo(telefone, nameof(Telefone))
			.ObjetoNulo(email, "e-mail")
			.Url(foto, nameof(Foto))
			.Validar();

		Nome = nome;
		Endereco = endereco;
		Telefone = telefone;
		Email = email;
		Foto = foto;
	}

}