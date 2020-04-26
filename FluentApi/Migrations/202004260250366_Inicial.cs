namespace FluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "venda.Clientes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "estoque.ProdutosAVenda",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "venda.ItensDaVenda",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProdutoId = c.Long(nullable: false),
                        VendaId = c.Long(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Desconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "venda.VendasRealizadas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("venda.VendasRealizadas");
            DropTable("venda.ItensDaVenda");
            DropTable("estoque.ProdutosAVenda");
            DropTable("venda.Clientes");
        }
    }
}
