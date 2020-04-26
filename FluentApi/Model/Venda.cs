using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Model
{
    public class Venda
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public virtual ICollection<VendaItem> ItensDaVenda { get; set; }
    }
}
