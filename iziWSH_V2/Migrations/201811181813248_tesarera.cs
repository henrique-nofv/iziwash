namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tesarera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "Logradouro", c => c.String());
            AddColumn("dbo.Vendas", "Uf", c => c.String());
            AddColumn("dbo.Vendas", "Localidade", c => c.String());
            AlterColumn("dbo.Vendas", "Cep", c => c.String(nullable: false));
            DropColumn("dbo.Vendas", "NomeRua");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "NomeRua", c => c.String());
            AlterColumn("dbo.Vendas", "Cep", c => c.String());
            DropColumn("dbo.Vendas", "Localidade");
            DropColumn("dbo.Vendas", "Uf");
            DropColumn("dbo.Vendas", "Logradouro");
        }
    }
}
