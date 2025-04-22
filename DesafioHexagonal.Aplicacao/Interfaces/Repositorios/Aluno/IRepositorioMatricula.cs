using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;

namespace DesafioHexagonal.Aplicacao.Interfaces;

public interface IRepositorioMatricula
{

    Task<MatriculaTDS> Obter(int numero);

    Task Inserir(MatriculaTDS matricula);

}
