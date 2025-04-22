using Bogus;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorTelefone
{

	private string? ddd;

	private string? numero;


	private ConstrutorTelefone() { }

	public static ConstrutorTelefone Criar()
	{
		return new ConstrutorTelefone();
	}

	public static Telefone CriarAleatorio()
	{ 
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Telefone? CriarNulo()
	{
		return null;
	}



	public ConstrutorTelefone ComDdd(string? ddd)
	{
		this.ddd = ddd;
		return this;
	}

	public ConstrutorTelefone ComNumero(string? numero)
	{
		this.numero = numero;
		return this;
	}

	public ConstrutorTelefone Aleatorio()
	{
		var gerador = new Faker();

		ComDdd(gerador.GerarTelefoneDdd());
		ComNumero(gerador.GerarTelefoneNumero());

		return this;
	}

	public Telefone Construir()
	{
		return new Telefone(ddd!, numero!);
	}

}
