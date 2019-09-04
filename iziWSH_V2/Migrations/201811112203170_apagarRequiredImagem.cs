namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apagarRequiredImagem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "ImagemCpf", c => c.String());
            AlterColumn("dbo.Clientes", "ImagemRg", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "ImagemRg", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "ImagemCpf", c => c.String(nullable: false));
        }
    }
}
