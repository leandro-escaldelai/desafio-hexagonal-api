using Bogus;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorProfessor
{

	private int? id;


	private ConstrutorProfessor() { }

	public static ConstrutorProfessor Criar()
	{
		return new ConstrutorProfessor();
	}

	public static Professor CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Professor? CriarNulo()
	{
		return null;
	}



	public ConstrutorProfessor ComId(int? id)
	{
		this.id = id;
		return this;
	}

	public ConstrutorProfessor Aleatorio()
	{
		var gerador = new Faker();

		ComId(gerador.Random.Int(1, 1000));

		return this;
	}

	public Professor Construir()
	{
		var professor = new Professor();

		if (id.HasValue)
			professor.GetType().GetProperty("Id")?.SetValue(professor, id);

		return professor;
	}

}
