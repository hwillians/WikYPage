namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new110 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Commentaires", name: "Article_Id", newName: "ArticleId");
            RenameIndex(table: "dbo.Commentaires", name: "IX_Article_Id", newName: "IX_ArticleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Commentaires", name: "IX_ArticleId", newName: "IX_Article_Id");
            RenameColumn(table: "dbo.Commentaires", name: "ArticleId", newName: "Article_Id");
        }
    }
}
