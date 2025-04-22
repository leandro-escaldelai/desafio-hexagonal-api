namespace DesafioHexagonal.Dominio.Excecoes;

public class ValidacaoException(
	params string[] erros) : DominioException
{

	public IEnumerable<string> Erros { get; private set; } = erros;

	public override string Message => 
		$"Ocorreram {erros.Length} erro(s) de validação: {string.Join(Environment.NewLine, erros)}";

}
