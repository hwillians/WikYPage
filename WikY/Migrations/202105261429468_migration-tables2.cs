namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationtables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Theme = c.String(nullable: false, maxLength: 30),
                        Auteur = c.String(nullable: false, maxLength: 30),
                        DateCreation = c.DateTime(nullable: false),
                        Contenu = c.String(nullable: false, maxLength: 3000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Auteur = c.String(nullable: false, maxLength: 30),
                        DateCreation = c.DateTime(nullable: false),
                        Contenu = c.String(nullable: false, maxLength: 300),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaires", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Commentaires", new[] { "Article_Id" });
            DropTable("dbo.Commentaires");
            DropTable("dbo.Articles");
        }
    }
}
