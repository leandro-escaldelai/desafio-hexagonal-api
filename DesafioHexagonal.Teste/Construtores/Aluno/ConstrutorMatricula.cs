using DesafioHexagonal.Dominio.Entidades;
using Bogus;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorMatricula
{

	private Perfil? perfil;

	private int? numero;

	private DateTime? data;


	private ConstrutorMatricula() { }

	public static ConstrutorMatricula Criar()
	{
		return new ConstrutorMatricula();
	}

	public static Matricula CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Matricula? CriarNulo()
	{
		return null;
	}



	public ConstrutorMatricula ComPerfil(Perfil? perfil)
	{
		this.perfil = perfil;
		return this;
	}

	public ConstrutorMatricula ComNumero(int? numero)
	{
		this.numero = numero;
		return this;
	}

	public ConstrutorMatricula ComData(DateTime? data)
	{
		this.data = data;
		return this;
	}

	public ConstrutorMatricula Aleatorio()
	{
		var gerador = new Faker();

		perfil = ConstrutorPerfil.CriarAleatorio();
		numero = gerador.Random.Int(1, 1000000);
		data = gerador.Date.Past(3, DateTime.Now);

		return this;
	}


	public Matricula Construir()
	{
		return new Matricula(perfil, numero, data);
	}

}
