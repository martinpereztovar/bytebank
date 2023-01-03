namespace ByteBank
{
    public class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("Bem-vindo!");
            Console.Write("Digite a opção desejada: ");
            Console.WriteLine("1 - Inserir um novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Ver detalhes de um usuário");
            Console.WriteLine("5 - Ver saldo no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Sair do programa");
        }

        static void RegisterNewUser(List<string> cpfs, List<string> names, List<string> senhas, List<double> saldos)
        {
            Console.WriteLine("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());
            Console.WriteLine("Digite o nome: ");
            names.Add(Console.ReadLine());
            Console.WriteLine("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }
        public static void Main(string[] args)
        {

        }
    }
}
