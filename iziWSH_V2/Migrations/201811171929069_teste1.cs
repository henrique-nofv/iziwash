    namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Logradouro", c => c.String());
            AddColumn("dbo.Clientes", "Uf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Uf");
            DropColumn("dbo.Clientes", "Logradouro");
        }
    }
}
