using System;
using System.Collections.Generic;

namespace Dio.Bank
{

    class Program    
    {
        static List<Conta> ListaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcao = OpcaoUsuario();

            while (opcao != 0)
            {
                switch(opcao)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Inserir();
                        break;
                    case 3:
                        Transferir();
                        break;
                    case 4:
                        Sacar();
                        break;
                    case 5:
                       Depositar();
                        break;
                    case 6:
                        Console.Clear();
                       break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcao = OpcaoUsuario();
            }
            Console.WriteLine("Obrigado e volte sempre!");
            Console.ReadLine();
        }

        private static void Inserir()
        {
            Console.WriteLine("Inserindo nova conta...");
            Console.WriteLine();
            Console.WriteLine("Digite 1 - Para pessoa Física");
            Console.WriteLine("Digite 2 - Para pessoa Jurídica");

            int entradaTipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta) entradaTipo,
                                    saldo: entradaSaldo,
                                    credito: entradaCredito,
                                    nome: entradaNome);
            
        
            ListaContas.Add(novaConta);
        }

        private static void Listar()
        {
            Console.WriteLine("LISTAR CONTAS: ");
            Console.WriteLine();

            if(ListaContas.Count == 0){
                Console.WriteLine("Nenhuma Conta Cadastrada!");
            }

            for (int i = 0; i < ListaContas.Count; i++){
                Conta conta = ListaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o valor de saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Sacar(valorSaque);

        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o valor de depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Depositar(valorDeposito);
        }

        private void Transferir()
        {
            Console.WriteLine("Digite o numero da Conta de origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da Conta de destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            ListaContas[indiceOrigem].Transferir(valorTransferencia, ListaContas[indiceDestino]);
        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("BANCO CLAUDIO!");
            Console.WriteLine("Informe qual operação deseja realizar:");

            Console.WriteLine();
            Console.WriteLine("Digite 1 - Para Listar contas");
            Console.WriteLine("Digite 2 - Para inserir nova conta");
            Console.WriteLine("Digite 3 - Para fazer uma transferência");
            Console.WriteLine("Digite 4 - Para realizar um saque");
            Console.WriteLine("Digite 5 - Para realizar um depósito");
            Console.WriteLine("Digite 6 - Para limpar a tela");
            Console.WriteLine("Digite 0 - Para sair");

            int opcao = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return opcao;

        }
    }
}
