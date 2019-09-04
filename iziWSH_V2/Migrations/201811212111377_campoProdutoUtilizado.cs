namespace iziWSH_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoProdutoUtilizado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "ProdutoUtilizado", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "ProdutoUtilizado");
        }
    }
}
