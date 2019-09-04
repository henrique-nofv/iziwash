namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "cliente_Id", c => c.Int());
            CreateIndex("dbo.Vendas", "cliente_Id");
            AddForeignKey("dbo.Vendas", "cliente_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Vendas", new[] { "cliente_Id" });
            DropColumn("dbo.Vendas", "cliente_Id");
        }
    }
}
