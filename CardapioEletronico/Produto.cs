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
    class Produto
    {
        [DataMember]
        public int Codigo { get; private set; }
        [DataMember]
        public string Descricao { get; private set; }
        public float ValorUnitario { get; private set; }

        public override string ToString()
        {
            return $"{Codigo}\t {Descricao}\t R${ValorUnitario.ToString("0.00")}";
        }
        
        public Produto(int codigo, string descricao, float valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
        }

    }

}
