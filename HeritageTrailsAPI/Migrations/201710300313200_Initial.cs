namespace HeritageTrailsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailStops",
                c => new
                    {
                        StopId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StopDesc = c.String(),
                        StopConstruct = c.String(),
                        StopLocation = c.String(),
                        StopCoordX = c.String(),
                        StopCoordY = c.String(),
                        StopImage = c.Int(nullable: false),
                        StopVideoURL = c.String(),
                        TrailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StopId)
                .ForeignKey("dbo.Trails", t => t.TrailId, cascadeDelete: true)
                .Index(t => t.TrailId);
            
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        TrailId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Time = c.String(),
                        Length = c.String(),
                        PictureInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrailId);
            
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        StopId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortDesc = c.String(),
                        Built = c.String(),
                        PictureInt = c.Int(nullable: false),
                        TrailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StopId)
                .ForeignKey("dbo.Trails", t => t.TrailId, cascadeDelete: true)
                .Index(t => t.TrailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stops", "TrailId", "dbo.Trails");
            DropForeignKey("dbo.DetailStops", "TrailId", "dbo.Trails");
            DropIndex("dbo.Stops", new[] { "TrailId" });
            DropIndex("dbo.DetailStops", new[] { "TrailId" });
            DropTable("dbo.Stops");
            DropTable("dbo.Trails");
            DropTable("dbo.DetailStops");
        }
    }
}
