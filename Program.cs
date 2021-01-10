using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUtilizador = ObterOpcaoUtilizador();
            while (opcaoUtilizador.ToUpper() != "X")
            {
                switch (opcaoUtilizador)
                {
                    case  "1":
                        ExibirContas();
                        break;
                    case  "2":
                        InserirConta();
                        break;
                    case  "3":
                        Transferir();
                        break;
                    case  "4":
                        Levantar();
                        break;
                    case  "5":
                        Depositar();
                        break;
                    case  "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUtilizador = ObterOpcaoUtilizador();
            }
            Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Introduza o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Introduza o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.Write("Introduza o valor a transferir: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Introduza o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Introduza o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Levantar()
        {
            Console.Write("Introduza o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Introduza o valor do levantamento: ");
            double valorLevantamento = double.Parse(Console.ReadLine());

            listContas[indiceConta].Levantar(valorLevantamento);
        }

        private static void ExibirContas()
        {
            Console.WriteLine("Lista de Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta registada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0] - ", i);
                Console.WriteLine(conta);    
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Escolha 1 para Conta Individual ou 2 para Conta Empresarial:");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Introduza o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Introduza o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Introduza o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);

        }

        private static string ObterOpcaoUtilizador()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!");
            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine("1 - Exibir as contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Levantar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar o ecrã");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUtilizador = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUtilizador;
        }
    }
}
