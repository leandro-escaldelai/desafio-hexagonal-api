using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.ObjetoValor;

public class Email
{

	public string Url { get; private set; } = string.Empty;


	private Email() { }

	public Email(string? url)
	{
		Validador.Criar()
			.Email(url, nameof(Url))
			.Validar();

		Url = url;
	}

}
