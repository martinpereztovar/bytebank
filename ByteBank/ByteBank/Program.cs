namespace ByteBank
{
    public class Program
        // Inicio dos métodos ou funções dentro do programa
    {
        // Mostrando o menu principal
        static void ShowMenu()
        {
            Console.WriteLine("1 - Registrar um novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Ver detalhes de um usuário");
            Console.WriteLine("5 - Ver saldo no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Sair do programa");
        }

        // Mostrando o menu secundario

        static void ShowSecondMenu()
        {
            Console.WriteLine("Digite a transação que deseja realizar: ");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Transferencia");
            Console.WriteLine("4 - Voltar ao menu principal");
        }


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

        // Inicio das funções do menu secundario

        // --- Função para depositar---

        static void SendMoney(List<double> balances, List<string> cpfs)
        {
            Console.WriteLine("Digite o CPF da conta destino: ");
            string cpfToSendMoney = Console.ReadLine();
            int indexToSendMoney = cpfs.FindIndex(cpf => cpf == cpfToSendMoney);

            if (indexToSendMoney == -1)
            {
                Console.WriteLine("Usuário ou conta não encontrados.");
            }
            else
            {
                Console.WriteLine("Digite o valor do deposito: ");
                double value = double.Parse(Console.ReadLine());
                balances[indexToSendMoney] += value;
                Console.WriteLine($"Deposito de R${value:F2} realizado com sucesso!");
            } 
        }
        // --- Função para saque---

        static void GetMoney(List<string>cpfs, List<double> balances)
        {
            
        Console.WriteLine("Digite o CPF da conta: ");
        string cpfToGetMoney = Console.ReadLine();
        int indexToGetMoney = cpfs.FindIndex(cpf => cpf == cpfToGetMoney);
        double value = 0;

            if (indexToGetMoney == -1)
            {
                Console.WriteLine("Usuário ou conta não encontrados.");
            }
            else
            {
                Console.WriteLine("Digite o valor do retiro: ");
                value = double.Parse(Console.ReadLine());
            } 

            if (balances[indexToGetMoney] < value) 
            {
                Console.WriteLine($"Saldo insuficiente. Seu saldo é {balances[indexToGetMoney]:F2}");
            }
            else
            {
                balances[indexToGetMoney] -= value;
                Console.WriteLine($"Retiro de R${value:F2} realizado com sucesso!");
                Console.WriteLine($"Seu saldo atual é R${balances[indexToGetMoney]:F2}");
            }
        }

        // --- Função para transferencia---

        static void TransferMoney(List<string> cpfs, List<double> balances)
        {
            Console.WriteLine("Digite o CPF da conta emisora: ");
            string cpfWhoSendMoney = Console.ReadLine();
            int indexWhoSendMoney = cpfs.FindIndex(cpf =>cpf == cpfWhoSendMoney);

            Console.WriteLine("Digite o CPF da conta destino: ");
            string cpfWhoReceiveMoney = Console.ReadLine();
            int indexWhoReceiveMoney = cpfs.FindIndex(cpf => cpf == cpfWhoReceiveMoney);

            if (indexWhoSendMoney== -1)
            {
                Console.WriteLine("Conta do emisor não encontrada.");
            }

            else if (indexWhoReceiveMoney == -1)
            {
                Console.WriteLine("Conta do destinatario não encontrada.");
            }

            else
            {
                Console.WriteLine("Digite o valor: ");
                double value = double.Parse(Console.ReadLine());

                if (balances[indexWhoSendMoney] < value)
                {
                    Console.WriteLine($"Saldo insuficiente. Seu saldo atual é {balances[indexWhoSendMoney]:F2}");
                }
                else
                {
                    balances[indexWhoSendMoney] -= value;
                    balances[indexWhoReceiveMoney] += value;
                    Console.WriteLine($"Transferencia de R${value:F2} realizada com sucesso");
                    Console.WriteLine($"Seu saldo atual é R${balances[indexWhoSendMoney]:F2}");
                }
            }


        }

        // --- Função que inicia o Menu secundario---

        static void BasicTransactions(List<string>cpfs, List<double>balances)
        {
            int option2;
            do
            {
                ShowSecondMenu();
                option2 = int.Parse(Console.ReadLine()); // lendo a opção do submenú
                Console.WriteLine("-----------------");

                switch (option2)
                {
                    case 1:
                        SendMoney(cpfs, balances);
                        break;
                    case 2:
                        GetMoney(cpfs, balances);
                        break;
                    case 3:
                        TransferMoney(cpfs, balances);
                        break;
                }
                Console.WriteLine("-----------------");
            }
            while(option2 != 0);

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

            // Solicitamos ao usuário que escolha uma opção para iniciar, após exibir o menú

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine()); // lendo a opção para começar a funcionar
                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Encerrando o programa... Até mais!");
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
                    case 6:
                        BasicTransactions(cpfs, balances); 
                        break;
                }
                Console.WriteLine("-----------------");

            } while (option != 0);
        }
    }
}
