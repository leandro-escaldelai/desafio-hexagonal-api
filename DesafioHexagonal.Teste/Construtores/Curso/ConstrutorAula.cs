using Bogus;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorAula
{

	private int? id;


	private ConstrutorAula() { }

	public static ConstrutorAula Criar()
	{
		return new ConstrutorAula();
	}

	public static Aula CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Aula? CriarNulo()
	{
		return null;
	}



	public ConstrutorAula ComId(int? id)
	{
		this.id = id;
		return this;
	}

	public ConstrutorAula Aleatorio()
	{
		var gerador = new Faker();

		ComId(gerador.Random.Int(1, 1000));

		return this;
	}

	public Aula Construir()
	{
		var aula = new Aula();

		if (id.HasValue)
			aula.GetType().GetProperty("Id")?.SetValue(aula, id);

		return aula;
	}

}
