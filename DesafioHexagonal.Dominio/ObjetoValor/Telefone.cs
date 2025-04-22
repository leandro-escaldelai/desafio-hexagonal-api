using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.ObjetoValor;

public class Telefone
{

	public string Numero { get; private set; } = string.Empty;


	private Telefone() { }

	public Telefone(string ddd, string numero)
	{
		Validador.Criar()
			.Ddd(ddd)
			.NumeroTelefone(numero)
			.Validar();

		Numero = $"({ddd}) {numero}";
	}

}
