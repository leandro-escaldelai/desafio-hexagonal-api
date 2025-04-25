using AutoMapper;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Aplicacao.TransferenciaDados.Saida
{
	public class HistoricoTDS
	{

		public int? Id { get; set; }

		public int? IdPerfil { get; set; }

		public string? Instituicao { get; set; }

		public string? Curso { get; set; }

		public string? Situacao { get; set; }

		public DateTime? DataInicio { get; set; }

		public DateTime? DataTermino { get; set; }

		public string? Descricao { get; set; }

		public string? UrlArquivo { get; set; }

	}


	public class HistoricoTDSProfile : Profile
	{

		public HistoricoTDSProfile()
		{
			CreateMap<Historico, HistoricoTDS>()
				.ForPath(d => d.IdPerfil, o => o.MapFrom(s => s.Perfil!.Id))
				.ReverseMap();
		}

	}	
}

