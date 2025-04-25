using DesafioHexagonal.Aplicacao.TransferenciaDados.Entrada;

namespace DesafioHexagonal.Aplicacao.Interfaces;


public interface ICriarPerfil
{

	Task<int?> CriarPerfil(PerfilTDE perfil);

}
