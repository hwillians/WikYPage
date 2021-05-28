namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Commentaires", "Article_Id");
            RenameColumn(table: "dbo.Commentaires", name: "Article_Id1", newName: "Article_Id");
            RenameIndex(table: "dbo.Commentaires", name: "IX_Article_Id1", newName: "IX_Article_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Commentaires", name: "IX_Article_Id", newName: "IX_Article_Id1");
            RenameColumn(table: "dbo.Commentaires", name: "Article_Id", newName: "Article_Id1");
            AddColumn("dbo.Commentaires", "Article_Id", c => c.Int(nullable: false));
        }
    }
}
