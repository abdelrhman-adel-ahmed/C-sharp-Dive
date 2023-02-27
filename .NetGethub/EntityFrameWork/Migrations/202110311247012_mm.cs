namespace EntityFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Videos", new[] { "PlayList_ID" });
            CreateIndex("dbo.Videos", "playlist_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Videos", new[] { "playlist_ID" });
            CreateIndex("dbo.Videos", "PlayList_ID");
        }
    }
}
