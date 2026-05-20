using Xunit;

public class ContaTests
{
    [Fact]
    public void Depositar_ValorPositivo_AumentaSaldo()
    {
        var conta = new Conta(1, "Teste", "00000000000", "senha", 0m, 0m);
        var result = conta.Depositar(100m, out string mensagem);
        Assert.True(result);
        Assert.Contains("Depósito realizado", mensagem);
        Assert.Equal(100m, conta.Saldo);
    }

    [Fact]
    public void Sacar_ComSaldoSuficiente_DecrementaSaldo()
    {
        var conta = new Conta(1, "Teste", "00000000000", "senha", 200m, 0m);
        var result = conta.Sacar(100m, out string mensagem);
        Assert.True(result);
        Assert.Equal(100m, conta.Saldo);
    }

    [Fact]
    public void Sacar_ComSaldoInsuficiente_RetornaErro()
    {
        var conta = new Conta(1, "Teste", "00000000000", "senha", 50m, 0m);
        var result = conta.Sacar(100m, out string mensagem);
        Assert.False(result);
        Assert.Contains("Saldo insuficiente", mensagem);
    }

    [Fact]
    public void AumentarLimite_AumentaLimiteCorretamente()
    {
        var conta = new Conta(1, "Teste", "00000000000", "senha", 0m, 100m);
        var result = conta.AumentarLimite(50m, out string mensagem);
        Assert.True(result);
        Assert.Equal(150m, conta.Limite);
    }

    [Fact]
    public void DiminuirLimite_ValorMaiorQueLimiteFalha()
    {
        var conta = new Conta(1, "Teste", "00000000000", "senha", 0m, 100m);
        var result = conta.DiminuirLimite(200m, out string mensagem);
        Assert.False(result);
        Assert.Contains("Não é possível", mensagem);
    }
}
