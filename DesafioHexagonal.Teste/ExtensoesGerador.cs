﻿using Bogus;
using DesafioHexagonal.Dominio.ObjetoValor;

namespace DesafioHexagonal.Teste.Dominio;

public static class ExtensoesGerador
{

	public static string GerarTelefoneDdd(this Faker gerador)
	{
		return gerador.PickRandom(new[] {
			"11", "12", "13", "14", "15", "16", "17", "18", "19",
			"21", "22", "24", "27", "28",
			"31", "32", "33", "34", "35", "37", "38",
			"41", "42", "43", "44", "45", "46", "47", "48", "49",
			"51", "53", "54", "55",
			"61", "62", "64", "65", "66", "67", "68", "69",
			"71", "73", "74", "75", "77", "79",
			"81", "82", "83", "84", "85", "86", "87", "88", "89",
			"91", "92", "93", "94", "95", "96", "97", "98", "99" });
	}

	public static string GerarTelefoneNumero(this Faker gerador)
	{
		var padrao = "####-####";

		return gerador.PickRandom(new[] {
			gerador.Phone.PhoneNumber(padrao),
			"9" + gerador.Phone.PhoneNumber(padrao) });
	}

	public static string GerarSituacaoHistorico(this Faker gerador)
	{
		return gerador.PickRandom(SituacaoHistorico.ObterListaValores());
	}

}
