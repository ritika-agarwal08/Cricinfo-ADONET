namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerName = c.String(nullable: false, maxLength: 40),
                        Country = c.String(nullable: false, maxLength: 20),
                        Link = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.PlayerName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
