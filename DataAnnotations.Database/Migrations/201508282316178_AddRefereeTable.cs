namespace DataAnnotations.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRefereeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Referees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Referees");
        }
    }
}
