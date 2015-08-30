namespace MultipleDbContexts.Second.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecondEntities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstProperty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecondEntities");
        }
    }
}
