namespace FluentApi.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.League",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(nullable: false, maxLength: 99, fixedLength: true),
                        Country = c.String(maxLength: 66, fixedLength: true),
                        NumberOfTeams = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stadium = c.String(maxLength: 30),
                        TimeStamp = c.Binary(),
                        YellowCards = c.Int(nullable: false),
                        RedCards = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "TrackDatabaseChanges", "True" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Date, t.Stadium }, name: "SomeIndexName");
            
            CreateTable(
                "PLayerSchema.Player",
                c => new
                    {
                        FirstName = c.String(maxLength: 8000, unicode: false),
                        Id = c.Int(nullable: false, identity: true),
                        FamilyName = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamPrimmaryKey = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TeamPrimmaryKey);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EGN = c.String(),
                        FirstName = c.String(),
                        FamilyName = c.String(),
                        Address_Id = c.Int(nullable: false),
                        Address_Town = c.String(),
                        Address_Stret = c.String(maxLength: 22),
                        Address_ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.League_Insert",
                p => new
                    {
                        Name = p.String(),
                        Abbreviation = p.String(maxLength: 99, fixedLength: true),
                        Country = p.String(maxLength: 66, fixedLength: true),
                        NumberOfTeams = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[League]([Name], [Abbreviation], [Country], [NumberOfTeams])
                      VALUES (@Name, @Abbreviation, @Country, @NumberOfTeams)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[League]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[League] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.League_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Abbreviation = p.String(maxLength: 99, fixedLength: true),
                        Country = p.String(maxLength: 66, fixedLength: true),
                        NumberOfTeams = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[League]
                      SET [Name] = @Name, [Abbreviation] = @Abbreviation, [Country] = @Country, [NumberOfTeams] = @NumberOfTeams
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.League_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[League]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.League_Delete");
            DropStoredProcedure("dbo.League_Update");
            DropStoredProcedure("dbo.League_Insert");
            DropIndex("dbo.Match", "SomeIndexName");
            DropTable("dbo.User");
            DropTable("dbo.Team");
            DropTable("PLayerSchema.Player");
            DropTable("dbo.Match",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "TrackDatabaseChanges", "True" },
                });
            DropTable("dbo.League");
            DropTable("dbo.Employee");
        }
    }
}
