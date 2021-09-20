using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioEletronico
{
    class Cardapio
    {
        private List<Produto> listaDeProdutos = new List<Produto>()
        {
            new Produto(100, "Cachorro quente", 5.70f),
            new Produto(101, "X Completo", 18.30f),
            new Produto(102, "X Salada", 16.50f),
            new Produto(103, "Hamburguer", 22.40f),
            new Produto(104, "Coca 2L", 10.00f),
            new Produto(105, "Refrigerante", 1.00f)
        };

        public List<Produto> RetornarListaDoCardapio()
        {
            return listaDeProdutos;
        }

        public Produto RetornarProdutoDaLista(int codigo)
        {
            foreach (Produto item in listaDeProdutos)
            {
                if (item.Codigo == codigo) return item;
            }
            return null;
        }

    }
}
