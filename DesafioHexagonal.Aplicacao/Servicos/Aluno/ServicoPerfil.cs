using AutoMapper;
using DesafioHexagonal.Aplicacao.Excessoes.Infraestrutura;
using DesafioHexagonal.Aplicacao.Interfaces;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Entrada;
using DesafioHexagonal.Aplicacao.TransferenciaDados.Saida;
using DesafioHexagonal.Dominio.Entidades;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Aplicacao.Servicos;

public class ServicoPerfil(
	IRepositorioPerfil repo,
	IMapper mapeador) : ICriarPerfil, IAtualizarPerfil
{

	public async Task<int?> CriarPerfil(PerfilTDE perfilTDE)
	{
		var perfil = new Perfil(
			perfilTDE.Nome,
			perfilTDE.Endereco,
			new Telefone(perfilTDE.Ddd, perfilTDE.NumeroTelefone),
			new Email(perfilTDE.Email),
			perfilTDE.Foto);

		var perfilTDS = mapeador.Map<PerfilTDS>(perfil);

		await repo.Inserir(perfilTDS);

		return perfilTDS.Id;
	}

	public async Task<int?> AtualizarPerfil(PerfilTDE perfilTDE)
	{
		var perfilTDS = await repo.Obter(perfilTDE.Id);

		if (perfilTDS == null)
			throw new NaoEncontradoException();

		var perfil = mapeador.Map<Perfil>(perfilTDS);

		perfil.Atualizar(
			perfilTDE.Nome,
			perfilTDE.Endereco,
			new Telefone(perfilTDE.Ddd, perfilTDE.NumeroTelefone),
			new Email(perfilTDE.Email),
			perfilTDE.Foto);

		perfilTDS = mapeador.Map<PerfilTDS>(perfil);

		await repo.Alterar(perfilTDS);

		return perfilTDS.Id;
	}

}
