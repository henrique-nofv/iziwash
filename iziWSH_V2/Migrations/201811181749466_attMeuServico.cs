namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attMeuServico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "NomeServico", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "NomeServico");
        }
    }
}
