﻿using Bogus;

namespace DesafioHexagonal.Teste.Dominio;


public abstract class TesteBase
{

	protected Faker gerador = new Faker("pt_BR");


	protected DateTime? ObterData(string? valor)
	{
		return DateTime.TryParse(valor, out DateTime data)
			? data : null;
	}

}
