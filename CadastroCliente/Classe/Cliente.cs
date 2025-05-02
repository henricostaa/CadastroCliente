
using System.Text.Json;

namespace CadastroCliente.Classe
{
    class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }

        private static List<Cliente> clientes = new List<Cliente>();
        private static string caminhoArquivo = "clientes.json";

        private static void SalvarClientes()
        {
            string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivo, json);
        }
        private static void CarregarClientes()
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                clientes = JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
            }
        }


        static Cliente()
        {
            CarregarClientes();
        }

        public Cliente()
        {
            Nome = "";
            Idade = 0;
            Email = "";
        }

        public Cliente(string nome, int idade, string email)
        {

            Nome = nome;
            Idade = idade;
            Email = email;
        }

        public void CadastrarCliente()
        {
            string nome;
            int idade;
            string email;

            while (true)
            {
                Console.Write("Digite o nome: ");
                nome = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(nome))
                    break;
                Console.WriteLine("Nome não pode ser vazio. Tente novamente.");
            }

            while (true)
            {
                Console.Write("Digite a idade: ");
                if (int.TryParse(Console.ReadLine(), out idade) && idade > 0)
                    break;
                Console.WriteLine("Idade inválida. Deve ser um número maior que zero. Tente novamente.");
            }

            while (true)
            {
                Console.Write("Digite o e-mail: ");
                email = Console.ReadLine()!;
                if (email.Contains("@"))
                    break;
                Console.WriteLine("E-mail inválido. Certifique-se de incluir '@'. Tente novamente.");
            }

            Cliente cliente = new Cliente(nome, idade, email);
            clientes.Add(cliente);
            SalvarClientes();
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void ListarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine(" Nenhum cliente cadastrado.");
                return;
            }

            Console.WriteLine("\n Lista de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($" Nome: {cliente.Nome}, Idade: {cliente.Idade}, Email: {cliente.Email}");
            }
        }

        public void BuscarCliente()
        {
            Console.Write("Digite o nome para buscar: ");
            string nomeBusca = Console.ReadLine()!;

            var encontrados = clientes.Where(c => c.Nome.Contains(nomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

            if (encontrados.Count == 0)
            {
                Console.WriteLine(" Nenhum cliente encontrado.");
                return;
            }

            Console.WriteLine("\nClientes encontrados:");
            foreach (var cliente in encontrados)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}, Email: {cliente.Email}");
            }
        }

        public void RemoverCliente()
        {
            Console.Write("Digite o nome do cliente que deseja remover: ");
            string nomeRemover = Console.ReadLine()!;

            var cliente = clientes.FirstOrDefault(c => c.Nome.Equals(nomeRemover));

            if (cliente == null)
            {
                Console.WriteLine(" Cliente não encontrado.");
                return;
            }

            clientes.Remove(cliente);
            SalvarClientes();
            Console.WriteLine("Cliente removido com sucesso!");
        }
    }
}
