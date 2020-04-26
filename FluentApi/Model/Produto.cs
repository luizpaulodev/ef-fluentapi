using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Model
{
    public class Produto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<VendaItem> VendaItens { get; set; }
    }
}
