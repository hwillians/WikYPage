namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class theme : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Articles", new[] { "Theme" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Articles", "Theme", unique: true);
        }
    }
}
