namespace DataAnnotations.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoalScoredAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "GoalScored", c => c.Int(nullable: false, defaultValue: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "GoalScored");
        }
    }
}
