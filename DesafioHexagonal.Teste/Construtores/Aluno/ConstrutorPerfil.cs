using Bogus;
using DesafioHexagonal.Dominio.Entidades;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorPerfil
{

	private int? id;

	private string? nome;

	private string? endereco;

	private Telefone? telefone;

	private Email? email;

	private string? foto;


	private ConstrutorPerfil() { }

	public static ConstrutorPerfil Criar()
	{
		return new ConstrutorPerfil();
	}

	public static Perfil CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static Perfil? CriarNulo()
	{
		return null;
	}



	public ConstrutorPerfil ComId(int? id)
	{
		this.id = id;
		return this;
	}

	public ConstrutorPerfil ComNome(string? nome)
	{
		this.nome = nome;
		return this;
	}

	public ConstrutorPerfil ComEndereco(string? endereco)
	{
		this.endereco = endereco;
		return this;
	}

	public ConstrutorPerfil ComTelefone(string? ddd, string? numero)
	{
		this.telefone = new Telefone(ddd!, numero!);
		return this;
	}

	public ConstrutorPerfil ComTelefone(Telefone? telefone)
	{
		this.telefone = telefone;
		return this;
	}

	public ConstrutorPerfil ComEmail(string? email)
	{
		this.email = new Email(email!);
		return this;
	}

	public ConstrutorPerfil ComEmail(Email? email)
	{
		this.email = email;
		return this;
	}

	public ConstrutorPerfil ComFoto(string? foto)
	{
		this.foto = foto;
		return this;
	}

	public ConstrutorPerfil Aleatorio()
	{
		var gerador = new Faker();

		ComId(gerador.Random.Int(1, 1000));
		ComNome(gerador.Name.FullName());
		ComEndereco(gerador.Address.FullAddress());
		ComTelefone(gerador.GerarTelefoneDdd(), gerador.GerarTelefoneNumero());
		ComEmail(gerador.Internet.Email());
		ComFoto(gerador.Image.PicsumUrl());

		return this;
	}

	public Perfil Construir()
	{
		var perfil = new Perfil(
			nome,
			endereco,
			telefone,
			email,
			foto
		);

		if (id.HasValue)
			perfil.GetType().GetProperty("Id")?.SetValue(perfil, id);

		return perfil;
	}

}
