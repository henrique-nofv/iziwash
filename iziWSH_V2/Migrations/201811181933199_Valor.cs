namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "Valor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "Valor");
        }
    }
}
