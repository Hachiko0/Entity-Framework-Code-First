namespace MultipleDbContexts.First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstContextInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FirstEntities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstProperty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FirstEntities");
        }
    }
}
