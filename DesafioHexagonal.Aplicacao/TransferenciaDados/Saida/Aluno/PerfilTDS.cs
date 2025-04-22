using AutoMapper;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Aplicacao.TransferenciaDados.Saida
{
    public class PerfilTDS
    {

        public int? Id { get; set; }

        public string? Nome { get; set; }

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public string? Foto { get; set; }

    }



    public class PerfilProfile : Profile
    {

        public PerfilProfile()
        {
			CreateMap<Perfil, PerfilTDS>()
				.ForPath(d => d.Telefone, o => o.MapFrom(s => s.Telefone!.Numero))
				.ForPath(dest => dest.Email, opt => opt.MapFrom(src => src.Email!.Url))
				.ReverseMap();
		}

	}

}

