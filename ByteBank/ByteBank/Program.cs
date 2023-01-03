namespace ByteBank
{
    public class Program
    {
        // Mostrando o menu principal
        static void ShowMenu()
        {
            Console.Write("Digite a opção desejada: ");
            Console.WriteLine("1 - Registrar um novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Ver detalhes de um usuário");
            Console.WriteLine("5 - Ver saldo no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Sair do programa");
        }

        // Inicio dos métodos ou funções dentro do programa

        // --- Função para registrar novos usuários---
        static void RegisterNewUser(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances)
        {
            Console.WriteLine("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());
            Console.WriteLine("Digite o nome: ");
            names.Add(Console.ReadLine());
            Console.WriteLine("Digite a senha: ");
            passwords.Add(Console.ReadLine());
            balances.Add(0);
        }

        // --- Função para deletar novos usuários---
        static void DeleteUser(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances)
        {
            Console.WriteLine("Digite o CPF: ");
            string cpfToDelete = Console.ReadLine();
            int indexToDelete = cpfs.FindIndex(cpf => cpf == cpfToDelete);

            if (indexToDelete == -1)
            {
                Console.WriteLine("Conta não encontrada.");
            }

            cpfs.Remove(cpfToDelete);
            names.RemoveAt(indexToDelete);
            passwords.RemoveAt(indexToDelete);
            balances.RemoveAt(indexToDelete);

            Console.WriteLine("Conta deletada corretamente.");

        }

        // --- Função para mostrar a conta do usuário---
        static void ShowUserAccount(int index, List<string> cpfs, List<string> names, List<double> balances)
        {
            Console.WriteLine($"CPF: {cpfs[index]} || Nome: {names[index]} || Saldo: R${balances[index]:F2}");
        }

        // --- Função para mostrar todos os usuários---
        static void ListUsers(List<string> cpfs, List<string> names, List<double> balances)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ShowUserAccount(i, cpfs, names, balances);
            }
        }

        // --- Função para mostrar um usuário---
        static void ShowUser(List<string> cpfs, List<string> names, List<double> balances)
        {
            Console.WriteLine("Digite o CPF: ");
            string cpfToShow = Console.ReadLine();
            int indexToShow = cpfs.FindIndex(cpf => cpf == cpfToShow);

            if (indexToShow == -1)
            {
                Console.WriteLine("Usuário ou conta não encontrados.");
            }

            ShowUserAccount(indexToShow, cpfs, names, balances);
        }

        // --- Função para mostrar saldo total no banco---
        static void ShowUserBalance(List<double> balances)
        {
            Console.WriteLine($"Saldo total no banco: {balances.Sum()}");
        }
        public static void Main(string[] args)
        {
            // Para o usuário, o programa realmente inicia aqui. 

            Console.WriteLine("Bem vido, seleccione a transação que deseja realizar: ");

            // Criação das listas para utilizar durante todo o programa.
            List<string> cpfs = new List<string>();
            List<string> names = new List<string>();
            List<string> passwords = new List<string>();    
            List<double> balances = new List<double>();

            // Solicitamos ao usuátio que escolha uma opção para iniciar, após exibir o menú

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine()); // lendo a opção para começar a funcionar
                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Encerrando o progrma... Até mais!");
                        break;
                    case 1: 
                        RegisterNewUser(cpfs, names, passwords, balances);
                        break;
                    case 2:
                        DeleteUser(cpfs, names, passwords, balances);
                        break;
                    case 3:
                        ListUsers(cpfs, names, balances);
                        break;
                    case 4:
                        ShowUser(cpfs, names, balances);
                        break;
                    case 5:
                        ShowUserBalance(balances); 
                        break;
                    //case 6:

                }
                Console.WriteLine("-----------------");

            } while (option != 0);
        }
    }
}
