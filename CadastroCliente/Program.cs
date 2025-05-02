using CadastroCliente.Classe;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroCliente
{
    class Program
    {
        static void Main()
        {
            var cliente = new Cliente();
            int opcao;
            do
            {
                Console.WriteLine("\nSistema de Cadastro de Clientes");
                Console.WriteLine("1-Cadastrar novo cliente");
                Console.WriteLine("2-Listar todos os clientes");
                Console.WriteLine("3-Buscar cliente por nome");
                Console.WriteLine("4-Remover cliente por nome");
                Console.WriteLine("0-Sair");

                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:

                        cliente.CadastrarCliente();
                        break;
                    case 2:
                        cliente.ListarClientes();
                        break;
                    case 3:
                        cliente.BuscarCliente();
                        break;
                    case 4:
                        cliente.RemoverCliente();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
