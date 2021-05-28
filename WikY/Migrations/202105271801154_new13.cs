namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new13 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Articles", "Theme", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Articles", new[] { "Theme" });
        }
    }
}
