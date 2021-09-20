using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardapioEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                menu = Menu();
            }
        }
        private static bool Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");

            switch (Console.ReadLine())
            {
                case "1":
                    Pedido();
                    return true;

                case "2":
                    return false;

                default:
                    return true;
            }
        }
        private static void Pedido()
        {
            Console.Clear();
            Cardapio cardapio = new Cardapio();
            Pedido pedido = new Pedido();
            Produto produto = null;

            string mesa = ValidaMesa();

            int codigoInformado = 0;
            int quantidade = 0;

            while (codigoInformado != 999)
            {
                MostrarCardapio(cardapio);
                Console.Write("Informe o Codigo: ");
                codigoInformado = int.Parse(Console.ReadLine());

                produto = cardapio.RetornarProdutoDaLista(codigoInformado);

                if (produto != null)
                {
                    Console.Write("Informe a Quantidade: ");
                    quantidade = 0;
                    while (quantidade <= 0)
                    {
                        quantidade = int.Parse(Console.ReadLine());
                        Console.Write("Informe a Quantidade válida: ");
                    }
                    pedido.AdicionarProdutoAoPedido(produto, quantidade);
                    produto = null;
                }
            }

            Console.WriteLine($"A mesa {mesa} pediu os seguintes itens: ");
            Console.WriteLine(pedido.ToString());

            Console.WriteLine();
            MostraFormatoJson(pedido);
            Console.WriteLine();

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        private static void MostrarCardapio(Cardapio cardapio)
        {
            Console.Clear();
            Console.WriteLine("Código\t Produto\t Preço Unitário (R$)");
            foreach (Produto produto in cardapio.RetornarListaDoCardapio())
            {
                Console.WriteLine(produto.ToString());
            }
            Console.WriteLine("999\t Encerrar Pedido");
        }
        private static string ValidaMesa()
        {
            string[] mesas = new string[] { "1", "2", "3", "4" };
            while (true)
            {
                Console.Write("Qual o numero da mesa: ");
                string numeroMesa = Console.ReadLine();
                foreach (string mesa in mesas)
                {
                    if (numeroMesa == mesa) return numeroMesa;
                }
            }
        }
        private static void MostraFormatoJson(Pedido pedido)
        {
            var json = JsonConvert.SerializeObject(pedido, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
