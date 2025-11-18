using static System.Console;

public class UX
{
    private readonly Banco _banco;
    private readonly string _titulo;

    public UX(string titulo, Banco banco)
    {
        _titulo = titulo;
        _banco = banco;
    }

    public void Executar()
    {
        CriarTitulo(_titulo);
        WriteLine(" [1] Criar Conta");
        WriteLine(" [2] Listar Contas");
        WriteLine(" [3] Efetuar Saque");
        WriteLine(" [4] Efetuar Depósito");
        WriteLine(" [5] Aumentar Limite");
        WriteLine(" [6] Diminuir Limite");

        ForegroundColor = ConsoleColor.Red;
        WriteLine("
 [9] Sair");
        ForegroundColor = ConsoleColor.White;

        CriarLinha();
        ForegroundColor = ConsoleColor.Yellow;
        Write(" Digite a opção desejada: ");
        var opcao = ReadLine() ?? "";
        ForegroundColor = ConsoleColor.White;

        switch (opcao)
        {
            case "1": CriarConta(); break;
            case "2": MenuListarContas(); break;
            case "3": MenuSaque(); break;
            case "4": MenuDeposito(); break;
            case "5": MenuAumentarLimite(); break;
            case "6": MenuDiminuirLimite(); break;
        }

        if (opcao != "9")
        {
            Executar();
        }

        _banco.SaveContas();
    }

    private void CriarConta() {}
    private void MenuListarContas() {}
    private void MenuSaque() {}
    private void MenuDeposito() {}
    private void MenuAumentarLimite() {}
    private void MenuDiminuirLimite() {}
    private void CriarLinha() {}
    private void CriarTitulo(string titulo) {}
    private void CriarRodape(string? mensagem = null) {}
}