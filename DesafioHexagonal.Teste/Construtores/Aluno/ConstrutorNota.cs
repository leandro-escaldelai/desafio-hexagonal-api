using Bogus;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorNota
{

	private int? id;

	private Perfil? perfil;

	private Professor? professor;

	private Aula? aula;

	private decimal? valor;


	private ConstrutorNota() { }

	public static ConstrutorNota Criar()
	{
		return new ConstrutorNota();
	}

	public static Nota CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Nota? CriarNulo()
	{
		return null;
	}


	public ConstrutorNota ComId(int? id)
	{
		this.id = id;
		return this;
	}

	public ConstrutorNota ComPerfil(Perfil? perfil)
	{
		this.perfil = perfil;
		return this;
	}

	public ConstrutorNota ComProfessor(Professor? professor)
	{
		this.professor = professor;
		return this;
	}

	public ConstrutorNota ComAula(Aula? aula)
	{
		this.aula = aula;
		return this;
	}

	public ConstrutorNota ComValor(decimal? valor)
	{
		this.valor = valor;
		return this;
	}

	public ConstrutorNota Aleatorio()
	{
		var gerador = new Faker();

		ComId(gerador.Random.Int(1, 1000));
		ComPerfil(ConstrutorPerfil.CriarAleatorio());
		ComProfessor(ConstrutorProfessor.CriarAleatorio());
		ComAula(ConstrutorAula.CriarAleatorio());
		ComValor(gerador.Random.Decimal(0, 10));

		return this;
	}

	public Nota Construir()
	{
		var nota = new Nota(perfil, professor, aula, valor);

		if (id.HasValue)
			nota.GetType().GetProperty("Id")?.SetValue(nota, id);

		return nota;
	}

}
