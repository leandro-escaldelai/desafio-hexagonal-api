using Bogus;
using DesafioHexagonal.Dominio.Entidades;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorContato
{

	private int? id;

	private string? nome;

	private Perfil? perfil;

	private Telefone? telefone;

	private Email? email;


	private ConstrutorContato() { }

	public static ConstrutorContato Criar()
	{
		return new ConstrutorContato();
	}

	public static Contato CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Contato? CriarNulo()
	{
		return null;
	}



	public ConstrutorContato ComId(int? id)
	{
		this.id = id;
		return this;
	}

	public ConstrutorContato ComNome(string? nome)
	{
		this.nome = nome;
		return this;
	}

	public ConstrutorContato ComPerfil(Perfil? perfil)
	{
		this.perfil = perfil;
		return this;
	}

	public ConstrutorContato ComTelefone(string? ddd, string? numero)
	{
		this.telefone = new Telefone(ddd!, numero!);
		return this;
	}

	public ConstrutorContato ComTelefone(Telefone? telefone)
	{
		this.telefone = telefone;
		return this;
	}

	public ConstrutorContato ComEmail(string? email)
	{
		this.email = new Email(email!);
		return this;
	}

	public ConstrutorContato ComEmail(Email? email)
	{
		this.email = email;
		return this;
	}

	public ConstrutorContato Aleatorio()
	{
		var gerador = new Faker();

		ComId(gerador.Random.Int(1, 1000));
		ComNome(gerador.Name.FullName());
		ComPerfil(ConstrutorPerfil.Criar().Aleatorio().Construir());
		ComTelefone(gerador.GerarTelefoneDdd(), gerador.GerarTelefoneNumero());
		ComEmail(gerador.Internet.Email());

		return this;
	}

	public Contato Construir()
	{
		var contato = new Contato(
			perfil,
			nome,
			telefone,
			email
		);

		if (id.HasValue)
			contato.GetType().GetProperty("Id")?.SetValue(contato, id);

		return contato;
	}

}
