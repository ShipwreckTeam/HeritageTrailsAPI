namespace HeritageTrailsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "FullDesc", c => c.String());
            AddColumn("dbo.Stops", "Location", c => c.String());
            AddColumn("dbo.Stops", "CoordX", c => c.String());
            AddColumn("dbo.Stops", "CoordY", c => c.String());
            AddColumn("dbo.Stops", "Image", c => c.Int(nullable: false));
            AddColumn("dbo.Stops", "VideoURL", c => c.String());
            DropColumn("dbo.Stops", "PictureInt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stops", "PictureInt", c => c.Int(nullable: false));
            DropColumn("dbo.Stops", "VideoURL");
            DropColumn("dbo.Stops", "Image");
            DropColumn("dbo.Stops", "CoordY");
            DropColumn("dbo.Stops", "CoordX");
            DropColumn("dbo.Stops", "Location");
            DropColumn("dbo.Stops", "FullDesc");
        }
    }
}
