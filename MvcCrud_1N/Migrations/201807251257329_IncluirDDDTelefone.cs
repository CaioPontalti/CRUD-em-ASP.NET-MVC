namespace MvcCrud_1N.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncluirDDDTelefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Telefones", "DDD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telefones", "DDD");
        }
    }
}
