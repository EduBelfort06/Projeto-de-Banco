using System;

public class SelfTestsRunner
{
    public static int Main()
    {
        int failures = 0;

        void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine("FAIL: " + message);
                failures++;
            }
            else
            {
                Console.WriteLine("OK: " + message);
            }
        }

        var c1 = new Conta(1, "T", "000", "s", 0m, 0m);
        c1.Depositar(100m, out var m1);
        Assert(c1.Saldo == 100m, "Depositar aumenta saldo");

        var c2 = new Conta(2, "T2", "111", "s2", 200m, 0m);
        c2.Sacar(50m, out var m2);
        Assert(c2.Saldo == 150m, "Sacar reduz saldo");

        var c3 = new Conta(3, "T3", "222", "s3", 10m, 0m);
        var ok = c3.Sacar(50m, out var m3);
        Assert(!ok, "Saque maior que saldo falha");

        var c4 = new Conta(4, "T4", "333", "s4", 0m, 100m);
        var ok2 = c4.DiminuirLimite(200m, out var m4);
        Assert(!ok2, "Diminuir limite além do permitido falha");

        Console.WriteLine($"Failures: {failures}");
        return failures > 0 ? 1 : 0;
    }
}
