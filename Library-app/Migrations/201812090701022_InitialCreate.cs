namespace Library_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 500),
                        Writer = c.String(),
                        Publisher = c.String(),
                        IsbnNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BookViewModels",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 500),
                        Writer = c.String(nullable: false, maxLength: 50),
                        Publisher = c.String(nullable: false),
                        IsbnNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookViewModels");
            DropTable("dbo.Libraries");
        }
    }
}
