namespace EntityFramework_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VideoPlayLists",
                c => new
                    {
                        Video_ID = c.Int(nullable: false),
                        PlayList_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_ID, t.PlayList_ID })
                .ForeignKey("dbo.Videos", t => t.Video_ID, cascadeDelete: true)
                .ForeignKey("dbo.PlayLists", t => t.PlayList_ID, cascadeDelete: true)
                .Index(t => t.Video_ID)
                .Index(t => t.PlayList_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoPlayLists", "PlayList_ID", "dbo.PlayLists");
            DropForeignKey("dbo.VideoPlayLists", "Video_ID", "dbo.Videos");
            DropIndex("dbo.VideoPlayLists", new[] { "PlayList_ID" });
            DropIndex("dbo.VideoPlayLists", new[] { "Video_ID" });
            DropTable("dbo.VideoPlayLists");
            DropTable("dbo.Videos");
            DropTable("dbo.PlayLists");
        }
    }
}
