using DesafioHexagonal.Dominio.Excecoes;

namespace DesafioHexagonal.Dominio.Validacoes;

public class Validador
{

	private readonly List<string> erros = new List<string>();

	private Validador() { }

	public static Validador Criar()
	{
		return new Validador();
	}



	public Validador Teste(bool condicao, string erro)
	{
		if (!condicao)
			erros.Add(erro);

		return this;
	}

	public Validador Teste(Func<bool> condicao, string erro)
	{
		if (!condicao())
			erros.Add(erro);

		return this;
	}

	public Validador TesteErro(Action condicao, string erro)
	{
		try
		{
			condicao();
		}
		catch
		{
			erros.Add(erro);
		}

		return this;
	}

	public Validador TesteLista<T>(IEnumerable<T> lista, T valorProcurado, string erro)
	{
		return Teste(lista.Contains(valorProcurado), erro);
	}

	public void Validar()
	{
		if (erros.Any())
			throw new ValidacaoException(erros.ToArray());
	}

}
