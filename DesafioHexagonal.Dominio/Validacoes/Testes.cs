using DesafioHexagonal.Dominio.Properties;
using System.Text.RegularExpressions;

namespace DesafioHexagonal.Dominio.Validacoes;

public static class Testes
{

	public static Validador ObjetoNulo(this Validador validador, object? valor, string campo) =>
		validador.Teste(valor != null, string.Format(Resources.NaoPreenchido, campo));

	public static Validador TextoNuloOuVazio(this Validador validador, string? valor, string campo) =>
		validador.Teste(!string.IsNullOrEmpty(valor), string.Format(Resources.NaoPreenchido, campo));

	public static Validador TextoNuloOuEspacoEmBranco(this Validador validador, string? valor, string campo) =>
		validador.Teste(!string.IsNullOrWhiteSpace(valor), string.Format(Resources.NaoPreenchido, campo));

	public static Validador Data(this Validador validador, DateTime? valor, string campo) =>
		validador.Teste(valor.HasValue && valor > DateTime.MinValue, string.Format(Resources.DataInvalida, campo));

	public static Validador DataInicioFim(this Validador validador, DateTime? inicio, DateTime? fim, string campoInicio, string campoFim)
	{
		validador.Data(inicio, campoInicio);

		if (!fim.HasValue)
			return validador;

		return validador.Teste(
			fim > inicio, 
			string.Format(Resources.DataInicioFimInvalidas, campoInicio, campoFim));
	}

	public static Validador DataFuturaProibida(this Validador validador, DateTime? data, string campo)
	{
		return validador.Teste(data <= DateTime.Now, 
			string.Format(Resources.DataFuturaProibida, campo));
	}

	public static Validador Url(this Validador validador, string? valor, string campo) =>
		validador.TesteErro(() => new Uri(valor!), string.Format(Resources.UrlInvalida, campo));

	public static Validador Email(this Validador validador, string? valor, string campo)
	{
		return validador.Teste(
			!string.IsNullOrWhiteSpace(valor) &&
			Regex.IsMatch(valor, Resources.EmailRegex),
			string.Format(Resources.EmailInvalido, campo)
		);
	}	public static Validador Ddd(this Validador validador, string? valor)
	{
		var valoresValidos = new[] {
			"11", "12", "13", "14", "15", "16", "17", "18", "19",
			"21", "22", "24", "27", "28",
			"31", "32", "33", "34", "35", "37", "38",
			"41", "42", "43", "44", "45", "46",
			"47", "48", "49",
			"51", "53", "54", "55",
			"61", "62", "64", "65", "66", "67", "68", "69",
			"71", "73", "74", "75", "77", "79",
			"81", "82", "83", "84", "85", "86", "87", "88", "89",
			"91", "92", "93", "94", "95", "96", "97", "98", "99"
		};

		return validador.Teste(
			valoresValidos.Contains(valor), 
			Resources.DddInvalido);
	}
	public static Validador NumeroTelefone(this Validador validador, string? valor)
	{
		return validador.Teste(
			!string.IsNullOrWhiteSpace(valor) &&
			Regex.IsMatch(valor, @"^\d{4,5}-\d{4}$"),
			Resources.NumeroTelefoneInvalido
		);
	}

}
