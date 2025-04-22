using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioHexagonal.Infraestrutura
{

    public static class Configuracao
    {

        public static void RegistrarRepositorios(this IServiceCollection servicos)
        {
            servicos.RegistrarUnidadeTrabalho();
			servicos.RegistrarAluno();
			servicos.RegistrarCurso();
        }


        private static void RegistrarUnidadeTrabalho(this IServiceCollection servicos)
        {
            servicos.AddScoped<IUnidadeTrabalho, UnidadeTrabalho>();
		}

		private static void RegistrarAluno(this IServiceCollection servicos)
        {
            servicos.AddScoped<IRepositorioContato, RepositorioContato>();
            servicos.AddScoped<IRepositorioHistorico, RepositorioHistorico>();
            servicos.AddScoped<IRepositorioMatricula, RepositorioMatricula>();
            servicos.AddScoped<IRepositorioNota, RepositorioNota>();
            servicos.AddScoped<IRepositorioPerfil, RepositorioPerfil>();
        }

		private static void RegistrarCurso(this IServiceCollection servicos)
        {

        }

    }

}
