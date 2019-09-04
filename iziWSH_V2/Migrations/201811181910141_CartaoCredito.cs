namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartaoCredito : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "NumeroCartao", c => c.Int(nullable: false));
            AddColumn("dbo.Vendas", "NomeCartao", c => c.String());
            AddColumn("dbo.Vendas", "Validade", c => c.String());
            AddColumn("dbo.Vendas", "CodSeguranca", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "CodSeguranca");
            DropColumn("dbo.Vendas", "Validade");
            DropColumn("dbo.Vendas", "NomeCartao");
            DropColumn("dbo.Vendas", "NumeroCartao");
        }
    }
}
