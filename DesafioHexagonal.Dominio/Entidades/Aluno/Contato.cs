using DesafioHexagonal.Dominio.ObjetoValor;
using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.Entidades;

public class Contato
{

	public int? Id { get; private set; }

	public Perfil? Perfil { get; private set; }

	public string? Nome { get; private set; }

	public Telefone? Telefone { get; private set; }

	public Email? Email { get; private set; }



	private Contato() { }

	public Contato(Perfil? perfil, string? nome, Telefone? telefone, Email? email)
	{
		Validador.Criar()
			.ObjetoNulo(perfil, nameof(Perfil))
			.TextoNuloOuVazio(nome, nameof(Nome))
			.ObjetoNulo(telefone, nameof(Telefone))
			.ObjetoNulo(email, "e-mail")
			.Validar();

		Perfil = perfil;
		Nome = nome;
		Telefone = telefone;
		Email = email;
	}

}