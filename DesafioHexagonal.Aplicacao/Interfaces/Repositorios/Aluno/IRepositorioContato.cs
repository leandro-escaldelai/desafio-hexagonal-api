using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;

namespace DesafioHexagonal.Aplicacao.Interfaces;

public interface IRepositorioContato
{

    Task<ContatoTDS> Obter(int id);

    Task<IEnumerable<ContatoTDS>> ObterLista(int idPerfil);

    Task Inserir(ContatoTDS contato);

    Task Alterar(ContatoTDS contato);

}
