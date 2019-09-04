namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Selfie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Selfie");
        }
    }
}
