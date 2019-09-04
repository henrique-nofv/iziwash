namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataHora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "DataHoraServico", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "DataHoraServico");
        }
    }
}
