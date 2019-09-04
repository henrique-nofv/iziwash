namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dlasuiidbasn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "Valor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "Valor", c => c.Double(nullable: false));
        }
    }
}
