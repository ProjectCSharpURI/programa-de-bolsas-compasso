using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CardapioEletronico
{
    [DataContract]
    class Pedido
    {
        [DataMember(Order = 1)]
        public float ValorTotal { get; private set; }
        [DataMember(Order = 2)]
        public List<Produto> Itens = new List<Produto>();

        public void AdicionarProdutoAoPedido(Produto produto, int quantidade)
        {
            ValorTotal += (produto.ValorUnitario * quantidade);
            Itens.Add(produto);
        }
        public override string ToString()
        {
            string pedido = string.Empty;
            int i = 1;
            foreach (Produto item in Itens)
            {
                pedido += $"{i} - {item.Descricao}\n";
                i++;
            }
            
            pedido += $"Com valor total de R$: {ValorTotal.ToString("0.00")}";
            return pedido;
        }


    }
}
