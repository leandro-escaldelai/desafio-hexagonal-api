using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.Entidades;

public class Nota
{

	public int? Id { get; set; }

	public Perfil? Perfil { get; set; }

	public Professor? Professor { get; set; }

	public Aula? Aula { get; set; }

	public decimal? Valor { get; set; }


	private Nota() { }

	public Nota(Perfil? perfil, Professor? professor, Aula? aula, decimal? valor)
	{
		Validador.Criar()
			.ObjetoNulo(perfil, nameof(Perfil))
			.ObjetoNulo(professor, nameof(Professor))
			.ObjetoNulo(aula, nameof(Aula))
			.NumeroPositivoOuZero(valor, nameof(Valor))
			.Validar();

		Perfil = perfil;
		Professor = professor;
		Aula = aula;
		Valor = valor;
	}

}