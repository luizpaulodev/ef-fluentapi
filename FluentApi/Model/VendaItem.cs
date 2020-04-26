using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Model
{
    public class VendaItem
    {
        public long Id { get; set; }
        public long ProdutoId { get; set; }
        public long VendaId { get; set; }
        private int _quantidade { get; set; }
        public int Quantidade { get { return _quantidade; } set { _quantidade = value; CalcularValorFinal(); } }
        public decimal Valor { get; set; }
        private decimal _desconto { get; set; } 
        public decimal Desconto { get { return _desconto; } set { _desconto = value; CalcularValorFinal(); } }
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }

        private void CalcularValorFinal()
        {
            if(Produto != null) {
                Valor = (Quantidade * Produto.Valor) - Desconto;
            }
        }
    }
}
