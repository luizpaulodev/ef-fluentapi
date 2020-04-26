using FluentApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoverVenda(2);
        }

        public static void RemoverVenda(long vendaId)
        {
            using (var contexto = new VendasContext())
            {
                var venda = contexto.Vendas.First(w => w.Id == vendaId);
                var vendaItem = venda.ItensDaVenda.First();

                contexto.Vendas.Remove(venda);
                contexto.VendaItens.Remove(vendaItem);
                contexto.SaveChanges();
            }
        }

        public static void AtualizarVenda()
        {
            // var vendaId = NovaVenda();
            var vendaId = 1;

            using (var contexto = new VendasContext())
            {
                var venda = contexto.Vendas.First(w => w.Id == vendaId);

                var vendaItem = venda.ItensDaVenda.First();
                vendaItem.Quantidade = 100;
                vendaItem.Desconto = 50;

                contexto.SaveChanges();
            }
        }

        public static long NovaVenda()
        {
            var cliente = new Cliente
            {
                Nome = "Luiz",
                DataNascimento = new DateTime(1990, 10, 15),
                Cpf = "999.999.999-99"
            };

            var produto = new Produto
            {
                Codigo = "9999",
                Descricao = "Camisa Adidas",
                Valor = 149
            };

            var itemVenda = new VendaItem();
            itemVenda.Produto = produto;
            itemVenda.Quantidade = 5;
            itemVenda.Desconto = 15;

            var venda = new Venda();
            venda.Cliente = cliente;
            venda.ItensDaVenda = new List<VendaItem>();
            venda.ItensDaVenda.Add(itemVenda);

            var contexto = new VendasContext();
            //contexto.Clientes.Add(cliente);
            contexto.Vendas.Add(venda);

            contexto.SaveChanges();

            return venda.Id;
        }
    }
}
