namespace HeritageTrailsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropDetailStop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailStops", "TrailId", "dbo.Trails");
            DropIndex("dbo.DetailStops", new[] { "TrailId" });
            DropTable("dbo.DetailStops");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.StopId);
            
            CreateIndex("dbo.DetailStops", "TrailId");
            AddForeignKey("dbo.DetailStops", "TrailId", "dbo.Trails", "TrailId", cascadeDelete: true);
        }
    }
}
