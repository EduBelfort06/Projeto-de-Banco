using System.Text.Json.Serialization;

public class Conta
{
    public int Numero { get; set; }
    public string Titular { get; set; }
    public decimal Saldo { get; private set; }
    public decimal Limite { get; private set; }

    public Conta(int numero, string titular, decimal saldoInicial = 0m, decimal limiteInicial = 0m)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldoInicial;
        Limite = limiteInicial;
    }

    // Deposit
    public bool Depositar(decimal valor, out string mensagem)
    {
        mensagem = "";
        if (valor <= 0)
        {
            mensagem = "Valor de depósito deve ser maior que zero.";
            return false;
        }

        Saldo += valor;
        mensagem = $"Depósito de {valor:C} realizado com sucesso. Saldo atual: {Saldo:C}.";
        return true;
    }

    // Withdraw
    public bool Sacar(decimal valor, out string mensagem)
    {
        mensagem = "";
        if (valor <= 0)
        {
            mensagem = "Valor de saque deve ser maior que zero.";
            return false;
        }

        decimal disponivel = Saldo + Limite;
        if (valor > disponivel)
        {
            mensagem = $"Saque negado. Limite disponível insuficiente. Disponível: {disponivel:C}.";
            return false;
        }

        Saldo -= valor;
        mensagem = $"Saque de {valor:C} realizado com sucesso. Saldo atual: {Saldo:C}.";
        return true;
    }

    // Aumentar limite
    public bool AumentarLimite(decimal valor, out string mensagem)
    {
        mensagem = "";
        if (valor <= 0)
        {
            mensagem = "Valor para aumentar limite deve ser maior que zero.";
            return false;
        }

        // opcional: validar limite máximo
        // decimal LIMITE_MAX = 10000m;
        // if (Limite + valor > LIMITE_MAX) { ... }

        Limite += valor;
        mensagem = $"Limite aumentado em {valor:C}. Limite atual: {Limite:C}.";
        return true;
    }

    // Diminuir limite
    public bool DiminuirLimite(decimal valor, out string mensagem)
    {
        mensagem = "";
        if (valor <= 0)
        {
            mensagem = "Valor para diminuir limite deve ser maior que zero.";
            return false;
        }

        if (valor > Limite)
        {
            mensagem = "Não é possível reduzir mais do que o limite atual.";
            return false;
        }

        decimal novoLimite = Limite - valor;

        // Verifica se a nova configuração de limite ainda cobre o saldo negativo atual
        if (Saldo < 0 && Math.Abs(Saldo) > novoLimite)
        {
            mensagem = $"Redução negada. Conta está com saldo negativo ({Saldo:C}) e o novo limite ({novoLimite:C}) não seria suficiente.";
            return false;
        }

        Limite = novoLimite;
        mensagem = $"Limite reduzido em {valor:C}. Limite atual: {Limite:C}.";
        return true;
    }
}
