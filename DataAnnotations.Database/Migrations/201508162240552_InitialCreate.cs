namespace DataAnnotations.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PrimaryKey = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        TeamPrimmaryKey = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrimaryKey)
                .ForeignKey("dbo.Teams", t => t.TeamPrimmaryKey, cascadeDelete: true)
                .Index(t => t.TeamPrimmaryKey);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamPrimmaryKey = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Division = c.String(),
                    })
                .PrimaryKey(t => t.TeamPrimmaryKey);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EGN = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        FamilyName = c.String(),
                        Address_Id = c.Int(nullable: false),
                        Address_Town = c.String(),
                        Address_Stret = c.String(),
                        Address_ZipCode = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.EGN });
            
            CreateTable(
                "dbo.UserForeignKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EGNId = c.String(nullable: false, maxLength: 128),
                        SomeData = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => new { t.UserId, t.EGNId }, cascadeDelete: true)
                .Index(t => new { t.UserId, t.EGNId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserForeignKeys", new[] { "UserId", "EGNId" }, "dbo.Users");
            DropForeignKey("dbo.Players", "TeamPrimmaryKey", "dbo.Teams");
            DropIndex("dbo.UserForeignKeys", new[] { "UserId", "EGNId" });
            DropIndex("dbo.Players", new[] { "TeamPrimmaryKey" });
            DropTable("dbo.UserForeignKeys");
            DropTable("dbo.Users");
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
