using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore_Produtos.Domains
{
    public class Pedido : BaseDomain
    {
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public object PedidosItens { get; internal set; }
    }
}
