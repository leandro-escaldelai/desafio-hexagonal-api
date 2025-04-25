using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.Entidades;

public class Matricula
{

	public Perfil? Perfil { get; private set; }

	public int? Numero { get; private set; }

	public DateTime? Data { get; private set; }


	private Matricula()	{ }

	public Matricula(Perfil? perfil, int? numero, DateTime? data)
	{
		Validador.Criar()
			.ObjetoNulo(perfil, nameof(Perfil))
			.NumeroPositivo(numero, "de matrícula")
			.DataFuturaProibida(data, "de matrícula")
			.Validar();

		Perfil = perfil;
		Numero = numero;
		Data = data;
	}

}