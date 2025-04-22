using DesafioHexagonal.Dominio.Properties;
using DesafioHexagonal.Dominio.Validacoes;

namespace DesafioHexagonal.Dominio.ObjetoValor;


public class SituacaoHistorico
{

	public string? Status { get; private set; }

	private SituacaoHistorico() { }

	public SituacaoHistorico(string? status)
	{
		Validar(status);

		Status = status;
	}



	public override bool Equals(object? obj)
	{
		if (obj is SituacaoHistorico situacao)
			return Status == situacao.Status;

		if (obj is string statusString)
			return Status == statusString;

		return false;
	}

	public override int GetHashCode()
	{
		return Status?.GetHashCode() ?? 0;
	}

	public static bool operator ==(SituacaoHistorico? situacao, string? status)
	{
		return situacao?.Status == status;
	}

	public static bool operator !=(SituacaoHistorico? situacao, string? status)
	{
		return situacao?.Status != status;
	}

	public static bool operator ==(string? status, SituacaoHistorico? situacao)
	{
		return situacao?.Status == status;
	}

	public static bool operator !=(string? status, SituacaoHistorico? situacao)
	{
		return situacao?.Status != status;
	}

	private void Validar(string? status)
	{
		var validador = Validador.Criar();

		validador.TextoNuloOuVazio(status, "Situação");
		validador.TesteLista(ObterListaValores(), status,
			Resources.SituacaoHistoricoInvalida);
		validador.Validar();
	}

	public static IEnumerable<SituacaoHistorico> ObterLista()
	{
		return [
			Ativo, Inativo, Trancado, Formado,
			Desistente, Cancelado, Jubilado, Transferido ];
	}

	public static IEnumerable<string> ObterListaValores()
	{
		return [
			Ativo.Status!, Inativo.Status!, Trancado.Status!, 
			Formado.Status!, Desistente.Status!, Cancelado.Status!, 
			Jubilado.Status!, Transferido.Status! ];
	}



	public static SituacaoHistorico Ativo => new SituacaoHistorico { Status = "Ativo" };
	public static SituacaoHistorico Inativo => new SituacaoHistorico { Status = "Inativo" };
	public static SituacaoHistorico Trancado => new SituacaoHistorico { Status = "Trancado" };
	public static SituacaoHistorico Formado => new SituacaoHistorico { Status = "Formado" };
	public static SituacaoHistorico Desistente => new SituacaoHistorico { Status = "Desistente" };
	public static SituacaoHistorico Cancelado => new SituacaoHistorico { Status = "Cancelado" };
	public static SituacaoHistorico Jubilado => new SituacaoHistorico { Status = "Jubilado" };
	public static SituacaoHistorico Transferido => new SituacaoHistorico { Status = "Transferido" };

}
