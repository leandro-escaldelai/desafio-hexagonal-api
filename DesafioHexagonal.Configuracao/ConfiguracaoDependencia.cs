using DesafioHexagonal.Aplicacao;
using DesafioHexagonal.Infraestrutura;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioHexagonal.Configuracao;

public static class ConfiguracaoDependencia
{

    public static void Registrar(this IServiceCollection servicos)
    {
        servicos.RegistrarRepositorios();
        servicos.RegistrarServicos();
    }

}
