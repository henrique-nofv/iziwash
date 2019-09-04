namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsadasdsad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendas", "Hora", c => c.String());
            DropColumn("dbo.Vendas", "DataHoraServico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "DataHoraServico", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vendas", "Hora");
            DropColumn("dbo.Vendas", "Data");
        }
    }
}
