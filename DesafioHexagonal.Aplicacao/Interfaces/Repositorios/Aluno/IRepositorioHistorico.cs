using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;

namespace DesafioHexagonal.Aplicacao.Interfaces;

public interface IRepositorioHistorico
{

	Task<HistoricoTDS> Obter(int id);

	Task<IEnumerable<HistoricoTDS>> ObterLista(int idPerfil);

	Task Inserir(HistoricoTDS historico);

	Task Alterar(HistoricoTDS historico);

}
