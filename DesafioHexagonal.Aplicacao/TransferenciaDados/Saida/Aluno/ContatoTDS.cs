using AutoMapper;
using DesafioHexagonal.Dominio.Entidades;

namespace DesafioHexagonal.Aplicacao.TransferenciaDados.Saida
{
    public class ContatoTDS
    {

        public int? Id { get; set; }

        public int? IdPerfil { get; set; }

        public string? Nome { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

    }



    public class ContatoTDSProfile : Profile
    {

        public ContatoTDSProfile()
        {
            CreateMap<Contato, ContatoTDS>()
                .ForPath(d => d.IdPerfil, o => o.MapFrom(s => s.Perfil!.Id))
                .ForPath(d => d.Telefone, o => o.MapFrom(s => s.Telefone!.Numero))
				.ForPath(d => d.Email, o => o.MapFrom(s => s.Email!.Url))
				.ReverseMap();
        }

    }

}
