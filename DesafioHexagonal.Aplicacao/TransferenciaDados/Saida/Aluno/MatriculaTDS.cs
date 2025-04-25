using AutoMapper;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Aplicacao.TransferenciaDados.Saida
{
    public class MatriculaTDS
    {

        public int? IdPerfil { get; set; }

        public int? Numero { get; set; }

        public DateTime? Data { get; set; }

    }


	public class MatriculaTDSProfile : Profile
	{
		public MatriculaTDSProfile()
		{
			CreateMap<Matricula, MatriculaTDS>()
				.ForPath(d => d.IdPerfil, o => o.MapFrom(s => s.Perfil!.Id))
				.ReverseMap();
		}
	}

}

