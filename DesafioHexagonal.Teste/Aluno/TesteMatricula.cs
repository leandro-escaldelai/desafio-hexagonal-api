using FluentAssertions;
using System.Reflection;

namespace DesafioHexagonal.Teste.Dominio;

public class TesteMatricula
{

    [Fact]
    public void Classe_Existe()
    {
        Assembly
            .Load("DesafioHexagonal.Dominio")
            .GetType("DesafioHexagonal.Dominio.Entidades.Matricula")
            .Should()
            .NotBeNull();
    }

}
