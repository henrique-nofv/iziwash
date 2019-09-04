namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cep : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cep", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Cep", c => c.Int(nullable: false));
        }
    }
}
