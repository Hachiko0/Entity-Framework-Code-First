namespace ConfigureMappings.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "FirstDev", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "FirstDev");
        }
    }
}
