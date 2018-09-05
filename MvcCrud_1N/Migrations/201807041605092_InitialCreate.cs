namespace MvcCrud_1N.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        IdConsultor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultores", t => t.IdConsultor, cascadeDelete: true)
                .Index(t => t.IdConsultor);
            
            CreateTable(
                "dbo.Consultores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Clientes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Clientes_Id)
                .Index(t => t.Clientes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefones", "Clientes_Id", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "IdConsultor", "dbo.Consultores");
            DropIndex("dbo.Telefones", new[] { "Clientes_Id" });
            DropIndex("dbo.Clientes", new[] { "IdConsultor" });
            DropTable("dbo.Telefones");
            DropTable("dbo.Consultores");
            DropTable("dbo.Clientes");
        }
    }
}
