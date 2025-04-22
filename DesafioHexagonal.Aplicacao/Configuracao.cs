using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioHexagonal.Aplicacao;

public static class Configuracao
{

    public static void RegistrarServicos(this IServiceCollection servicos)
    {
        RegistrarAluno(servicos);
        RegistrarCurso(servicos);
    }


    #region Aluno

    public static void RegistrarAluno(this IServiceCollection servicos)
    {
        servicos.RegistrarContato();
        servicos.RegistrarHistorico();
        servicos.RegistrarMatricula();
        servicos.RegistrarNota();
        servicos.RegistrarPerfil();
    }

    public static void RegistrarContato(this IServiceCollection servicos)
    {
        servicos.AddScoped<IIncluirContato, ServicoContato>();
        servicos.AddScoped<IAtualizarContato, ServicoContato>();
    }

    public static void RegistrarHistorico(this IServiceCollection servicos)
    {
        servicos.AddScoped<IIncluirHistorico, ServicoHistorico>();
        servicos.AddScoped<IAtualizarHistorico, ServicoHistorico>();
    }

    public static void RegistrarMatricula(this IServiceCollection servicos)
    {
        servicos.AddScoped<IEfetuarMatricula, ServicoMatricula>();
    }

    public static void RegistrarNota(this IServiceCollection servicos)
    {
        servicos.AddScoped<IAtribuirNota, ServicoNota>();
        servicos.AddScoped<IAtualizarNota, ServicoNota>();
    }

    public static void RegistrarPerfil(this IServiceCollection servicos)
    {
        servicos.AddScoped<ICriarPerfil, ServicoPerfil>();
        servicos.AddScoped<IAtualizarPerfil, ServicoPerfil>();
    }

    #endregion



    #region Curso

    public static void RegistrarCurso(this IServiceCollection servicos)
    {
    }

    #endregion


}
