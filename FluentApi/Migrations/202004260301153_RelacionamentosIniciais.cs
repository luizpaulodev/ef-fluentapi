namespace FluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionamentosIniciais : DbMigration
    {
        public override void Up()
        {
            CreateIndex("venda.VendasRealizadas", "ClienteId");
            CreateIndex("venda.ItensDaVenda", "ProdutoId");
            CreateIndex("venda.ItensDaVenda", "VendaId");
            AddForeignKey("venda.VendasRealizadas", "ClienteId", "venda.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("venda.ItensDaVenda", "ProdutoId", "estoque.ProdutosAVenda", "Id", cascadeDelete: true);
            AddForeignKey("venda.ItensDaVenda", "VendaId", "venda.VendasRealizadas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("venda.ItensDaVenda", "VendaId", "venda.VendasRealizadas");
            DropForeignKey("venda.ItensDaVenda", "ProdutoId", "estoque.ProdutosAVenda");
            DropForeignKey("venda.VendasRealizadas", "ClienteId", "venda.Clientes");
            DropIndex("venda.ItensDaVenda", new[] { "VendaId" });
            DropIndex("venda.ItensDaVenda", new[] { "ProdutoId" });
            DropIndex("venda.VendasRealizadas", new[] { "ClienteId" });
        }
    }
}
