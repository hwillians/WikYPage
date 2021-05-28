namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commentaires", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Commentaires", new[] { "Article_Id" });
            AddColumn("dbo.Commentaires", "Article_Id1", c => c.Int(nullable: false));
            AlterColumn("dbo.Commentaires", "Article_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Commentaires", "Article_Id1");
            AddForeignKey("dbo.Commentaires", "Article_Id1", "dbo.Articles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaires", "Article_Id1", "dbo.Articles");
            DropIndex("dbo.Commentaires", new[] { "Article_Id1" });
            AlterColumn("dbo.Commentaires", "Article_Id", c => c.Int());
            DropColumn("dbo.Commentaires", "Article_Id1");
            CreateIndex("dbo.Commentaires", "Article_Id");
            AddForeignKey("dbo.Commentaires", "Article_Id", "dbo.Articles", "Id");
        }
    }
}
