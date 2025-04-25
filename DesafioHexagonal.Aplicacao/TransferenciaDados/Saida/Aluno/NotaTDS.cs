using AutoMapper;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Aplicacao.TransferenciaDados.Saida
{
    public class NotaTDS
    {

        public int? Id { get; set; }

        public int? IdPerfil { get; set; }

	    public int? IdProfessor { get; set; }

        public int? IdAula { get; set; }

        public decimal? Valor { get; set; }

    }


	public class NotaTDSProfile : Profile
	{
		public NotaTDSProfile()
		{
			CreateMap<Nota, NotaTDS>()
				.ForPath(d => d.IdPerfil, o => o.MapFrom(s => s.Perfil!.Id))
				.ForPath(d => d.IdProfessor, o => o.MapFrom(s => s.Professor!.Id))
				.ForPath(d => d.IdAula, o => o.MapFrom(s => s.Aula!.Id))
				.ReverseMap();
		}
	}

}

