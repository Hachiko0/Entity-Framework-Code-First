namespace ConfigureMappings.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EGN = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        FamilyName = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.EGN });
            
            CreateTable(
                "dbo.UserForeignKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SomeData = c.String(),
                        UserId = c.Int(nullable: false),
                        EGNId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => new { t.UserId, t.EGNId }, cascadeDelete: true)
                .Index(t => new { t.UserId, t.EGNId });
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stadium = c.String(),
                        Crowd = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        HomeTeamId = c.Int(),
                        AwayTeamId = c.Int(nullable: false),
                        Referee_Id = c.Int(),
                        Referee_EGN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .ForeignKey("dbo.Referees", t => new { t.Referee_Id, t.Referee_EGN })
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => new { t.Referee_Id, t.Referee_EGN });
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        NumberOfTeams = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        SubstituteId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.SubstituteId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.SubstituteId);
            
            CreateTable(
                "dbo.PlayerAddresses",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                        Continent = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeagueTeam",
                c => new
                    {
                        LeagueId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LeagueId, t.TeamId })
                .ForeignKey("dbo.Teams", t => t.LeagueId, cascadeDelete: true)
                .ForeignKey("dbo.Leagues", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.LeagueId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.EmplooyeLikers",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        OtherEmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.OtherEmployeeId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.OtherEmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.OtherEmployeeId);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EGN = c.String(nullable: false, maxLength: 128),
                        Age = c.Int(nullable: false),
                        Nationality = c.String(),
                        WonTrophies = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.EGN })
                .ForeignKey("dbo.Users", t => new { t.Id, t.EGN })
                .Index(t => new { t.Id, t.EGN });
            
            CreateTable(
                "dbo.Referees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EGN = c.String(nullable: false, maxLength: 128),
                        YellowCardsShowed = c.Int(nullable: false),
                        RedCardsShowed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.EGN })
                .ForeignKey("dbo.Users", t => new { t.Id, t.EGN })
                .Index(t => new { t.Id, t.EGN });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referees", new[] { "Id", "EGN" }, "dbo.Users");
            DropForeignKey("dbo.Coaches", new[] { "Id", "EGN" }, "dbo.Users");
            DropForeignKey("dbo.EmplooyeLikers", "OtherEmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmplooyeLikers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.UserForeignKeys", new[] { "UserId", "EGNId" }, "dbo.Users");
            DropForeignKey("dbo.Matches", new[] { "Referee_Id", "Referee_EGN" }, "dbo.Referees");
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "SubstituteId", "dbo.Players");
            DropForeignKey("dbo.PlayerAddresses", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.LeagueTeam", "TeamId", "dbo.Leagues");
            DropForeignKey("dbo.LeagueTeam", "LeagueId", "dbo.Teams");
            DropIndex("dbo.Referees", new[] { "Id", "EGN" });
            DropIndex("dbo.Coaches", new[] { "Id", "EGN" });
            DropIndex("dbo.EmplooyeLikers", new[] { "OtherEmployeeId" });
            DropIndex("dbo.EmplooyeLikers", new[] { "EmployeeId" });
            DropIndex("dbo.LeagueTeam", new[] { "TeamId" });
            DropIndex("dbo.LeagueTeam", new[] { "LeagueId" });
            DropIndex("dbo.PlayerAddresses", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "SubstituteId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Matches", new[] { "Referee_Id", "Referee_EGN" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropIndex("dbo.UserForeignKeys", new[] { "UserId", "EGNId" });
            DropTable("dbo.Referees");
            DropTable("dbo.Coaches");
            DropTable("dbo.EmplooyeLikers");
            DropTable("dbo.LeagueTeam");
            DropTable("dbo.Employees");
            DropTable("dbo.PlayerAddresses");
            DropTable("dbo.Players");
            DropTable("dbo.Leagues");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.UserForeignKeys");
            DropTable("dbo.Users");
        }
    }
}
