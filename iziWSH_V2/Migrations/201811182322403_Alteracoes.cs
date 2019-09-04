namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracoes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "NomeCartao", c => c.String(nullable: false));
            AlterColumn("dbo.Vendas", "Validade", c => c.String(nullable: false));
            AlterColumn("dbo.Vendas", "NumeroRua", c => c.String(nullable: false));
            AlterColumn("dbo.Vendas", "ModeloCarro", c => c.String(nullable: false));
            AlterColumn("dbo.Vendas", "PlacaCarro", c => c.String(nullable: false));
            AlterColumn("dbo.Vendas", "MarcaCarro", c => c.String(nullable: false));
            AlterColumn("dbo.Vendas", "Hora", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "Hora", c => c.String());
            AlterColumn("dbo.Vendas", "MarcaCarro", c => c.String());
            AlterColumn("dbo.Vendas", "PlacaCarro", c => c.String());
            AlterColumn("dbo.Vendas", "ModeloCarro", c => c.String());
            AlterColumn("dbo.Vendas", "NumeroRua", c => c.String());
            AlterColumn("dbo.Vendas", "Validade", c => c.String());
            AlterColumn("dbo.Vendas", "NomeCartao", c => c.String());
        }
    }
}
