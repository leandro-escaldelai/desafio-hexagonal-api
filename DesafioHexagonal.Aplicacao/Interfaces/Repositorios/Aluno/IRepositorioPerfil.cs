using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;

namespace DesafioHexagonal.Aplicacao.Interfaces;

public interface IRepositorioPerfil
{

    Task<PerfilTDS> Obter(int id);

    Task Inserir(PerfilTDS Perfil);

    Task Alterar(PerfilTDS Perfil);

}
