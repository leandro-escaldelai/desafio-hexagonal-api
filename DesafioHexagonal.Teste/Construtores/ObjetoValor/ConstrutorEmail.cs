using Bogus;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorEmail
{

	private string? url;


	private ConstrutorEmail() { }

	public static ConstrutorEmail Criar()
	{
		return new ConstrutorEmail();
	}

	public static Email CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Email? CriarNulo()
	{
		return null;
	}



	public ConstrutorEmail ComUrl(string? url)
	{
		this.url = url;
		return this;
	}

	public ConstrutorEmail Aleatorio()
	{
		var gerador = new Faker();

		ComUrl(gerador.Internet.Email());

		return this;
	}

	public Email Construir()
	{
		return new Email(url!);
	}

}
