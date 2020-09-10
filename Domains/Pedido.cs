using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore_Produtos.Domains
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }


        Pedido()
        {
            Id = Guid.NewGuid();
        }
    }
}
