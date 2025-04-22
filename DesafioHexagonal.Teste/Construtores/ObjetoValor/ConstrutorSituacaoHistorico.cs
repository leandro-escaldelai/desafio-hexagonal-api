using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio.Construtores;

public class ConstrutorSituacaoHistorico
{

	private string? situacao;


	private ConstrutorSituacaoHistorico() { }

	public static ConstrutorSituacaoHistorico Criar()
	{
		return new ConstrutorSituacaoHistorico();
	}

	public static SituacaoHistorico CriarAleatorio()
	{
		return Criar()
			.Aleatorio()
			.Construir();
	}

	public static SituacaoHistorico? CriarNulo()
	{
		return null;
	}



	public ConstrutorSituacaoHistorico ComSituacao(string? situacao)
	{
		this.situacao = situacao;
		return this;
	}

	public ConstrutorSituacaoHistorico Aleatorio()
	{
		var gerador = new Bogus.Faker();
		ComSituacao(gerador.PickRandom(SituacaoHistorico.ObterListaValores()));
		return this;
	}

	public SituacaoHistorico Construir()
	{
		return new SituacaoHistorico(situacao);
	}

}
