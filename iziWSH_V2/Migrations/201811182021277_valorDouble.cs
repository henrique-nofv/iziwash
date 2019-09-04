namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valorDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "Valor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "Valor", c => c.String());
        }
    }
}
