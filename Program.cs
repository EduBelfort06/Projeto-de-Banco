public class Program
{
    public static void Main(string[] args)
    {
        var banco = new Banco();
        var ux = new UX("Sapiens Bank", banco);
        ux.Executar();
    }
}