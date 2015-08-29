namespace DataAnnotations.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayerAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Avatar", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Avatar");
        }
    }
}
