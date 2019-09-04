namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuscarrrCep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Localidade", c => c.String());
            AlterColumn("dbo.Clientes", "Cep", c => c.String(nullable: false));
            DropColumn("dbo.Clientes", "Rua");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Rua", c => c.String());
            AlterColumn("dbo.Clientes", "Cep", c => c.String());
            DropColumn("dbo.Clientes", "Localidade");
        }
    }
}
