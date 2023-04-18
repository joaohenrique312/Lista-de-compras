using System;
using System.Collections.Generic;

class Program
{
    static string Nome_Usuario;
    static string Senha_Registrada;
    static List<string> listaDeCompras = new List<string>();

    static void Main(string[] args)
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("É a sua primeira vez no serviço? (1- Sim, 2 - Não)");
            int.TryParse(Console.ReadLine(), out int confirme);

            switch (confirme)
            {
                case 1:
                    LimparTela();
                    RegistrarCliente();
                    break;
                case 2:
                    LimparTela();
                    if (Login())
                    {
                        loop = false;
                    }
                    break;
                default:
                    Console.WriteLine("Tente novamente.");
                    loop = false;
                    break;
            }
        }

        LimparTela();

        bool loop2 = true;
        while (loop2)
        {
            Console.WriteLine("O que deseja fazer? (1 - Começar a lista de compras, 2 - Verificar sua lista de compras, 3 - Adicionar item na lista de compras, 4 - Remover item na lista de compras, 5 - Resetar a lista de compras, 6 - Sair do aplicativo)");
            int.TryParse(Console.ReadLine(), out int opção);

            switch (opção)
            {
                case 1:
                    CriarListaDeCompras();
                    break;
                case 2:
                    Verificar();
                    break;
                case 3:
                    AdicionarItem();
                    break;
                case 4:
                    RemoverItem();
                    break;
                case 5:
                    ResetarLista();
                    break;
                case 6:
                    loop2 = false;
                    break;
                default:
                    Console.WriteLine("Comando inválido, tente novamente.");
                    Task.Delay(1000).Wait();
                    LimparTela();
                    break;

            }
        }

    }

    public static void LimparTela()
    {
        Console.Clear();
    }

    static bool FunçãoListaCriada = false;

    static void CriarListaDeCompras()
    {
        LimparTela();

        Console.WriteLine("Quantos produtos terá a sua lista de compras?");
        int.TryParse(Console.ReadLine(), out int qnt);

        for (int i = 0; i < qnt; i++)
        {
            LimparTela();
            Console.WriteLine($"Digite o {i + 1}° produto da Lista de Compras");
            string item = Console.ReadLine();
            listaDeCompras.Add(item);
        }

        LimparTela();
        Console.WriteLine("Segue abaixo os seus items da lista de compras:");
        foreach (string item in listaDeCompras)
        {
            Console.WriteLine(item);
        }

        Task.Delay(2000).Wait();
        LimparTela();
        FunçãoListaCriada = true;
    }

    static void AdicionarItem()
    {
        if (FunçãoListaCriada)
        {
            LimparTela();
            Console.WriteLine($"Digite o produto que você quer adicionar na Lista de Compras");
            string item = Console.ReadLine();
            listaDeCompras.Add(item);

            LimparTela();
            Console.WriteLine($"{item} adicionado na lista com sucesso");

            Task.Delay(1000).Wait();
            LimparTela();
        }
        else
        {
            Console.WriteLine("Lista não criada, crie ela antes de executar o comando.");
            Task.Delay(2000).Wait();
            LimparTela();
        }
    }

    static void RemoverItem()
    {
        LimparTela();

        if (FunçãoListaCriada)
        {
            Console.WriteLine("Segue a sua lista de compras.");
            foreach (string item in listaDeCompras)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Qual item dessa sua lista você deseja remover?");
            string itemRemover = Console.ReadLine();

            if (listaDeCompras.Contains(itemRemover))
            {
                listaDeCompras.Remove(itemRemover);

                Console.WriteLine($"{itemRemover} removido com sucesso!");
            }
            else
            {
                Console.WriteLine($"{itemRemover} não foi encontrado na lista...");
            }
        }
        else
        {
            Console.WriteLine("Lista não foi encontrada, crie antes de executar este comando.");
        }
        Task.Delay(2000).Wait();
        LimparTela();
    }

    static void Verificar()
    {
        if (FunçãoListaCriada)
        {
            LimparTela();

            if (listaDeCompras.Count > 0)
            {
                Console.WriteLine("Segue abaixo os seus items da lista de compras:");
                foreach (string item in listaDeCompras)
                {
                    Console.WriteLine(item);
                }

                Task.Delay(2000).Wait();
                LimparTela();
            }
            else
            {
                Console.WriteLine("A lista foi criada, mas não há produtos nela.");
            }
        }   
        else
        {
            Console.WriteLine("Lista não criada, crie ela antes de executar o comando.");
            Task.Delay(2000).Wait();
            LimparTela();
        }
    }

    static void ResetarLista()
    {
        if (FunçãoListaCriada)
        {
            bool loop = true;
            LimparTela();

            while (loop)
            {
                Console.WriteLine("Deseja resetar a sua lista? (1- Sim, 2 - Não)");
                int.TryParse(Console.ReadLine(), out int opção);

                if (opção == 1)
                {
                    listaDeCompras.Clear();
                    Console.WriteLine("Lista limpa com sucesso.");
                    loop = false;
                }
                else
                {
                    loop = false;
                }
            }
        }
    }

    static void RegistrarCliente()
    {
        Console.WriteLine("Seja bem vindo ao nosso aplicativo de lista de compras, primeiramente vamos fazer a sua conta!");

        Console.WriteLine("Digite o nome do usuário");
        string Nome_Usuário = Console.ReadLine();

        LimparTela();

        Console.WriteLine("Digite a sua senha: ");
        string senha = Console.ReadLine();

        LimparTela();

        Console.WriteLine("Registrando cliente...");
        Task.Delay(3000).Wait();

        Nome_Usuario = Nome_Usuário;
        Senha_Registrada = senha;

        Console.WriteLine("Conta registrada com sucesso!");
        Task.Delay(3000).Wait();
    }

    static bool Login()
    {
        while (true)
        {
            Console.WriteLine("Digite o seu usuário.");
            string nomeUsuarioLogin = Console.ReadLine();

            LimparTela();

            Console.WriteLine("Digite sua senha:");
            string senhaLogin = Console.ReadLine();

            if (senhaLogin == Senha_Registrada && nomeUsuarioLogin == Nome_Usuario)
            {
                LimparTela();

                Console.WriteLine("Verificando...");
                Task.Delay(2000).Wait();

                Console.WriteLine("Seja bem vindo: {0}!", nomeUsuarioLogin);
                Task.Delay(1000).Wait();

                return true;
            }
            else
            {
                Console.WriteLine("Tente novamente.");
            }
        }
    }
}