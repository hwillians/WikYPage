namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationlenCoontenu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Contenu", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Contenu", c => c.String(nullable: false, maxLength: 3000));
        }
    }
}
