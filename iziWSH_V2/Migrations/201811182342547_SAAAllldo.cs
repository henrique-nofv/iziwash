namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SAAAllldo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Saldo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Saldo");
        }
    }
}
