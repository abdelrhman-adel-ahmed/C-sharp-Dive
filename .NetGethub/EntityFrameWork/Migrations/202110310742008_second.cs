namespace EntityFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
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
            
            AddColumn("dbo.Videos", "PlayList_ID", c => c.Int());
            CreateIndex("dbo.Videos", "PlayList_ID");
            AddForeignKey("dbo.Videos", "PlayList_ID", "dbo.PlayLists", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "PlayList_ID", "dbo.PlayLists");
            DropIndex("dbo.Videos", new[] { "PlayList_ID" });
            DropColumn("dbo.Videos", "PlayList_ID");
            DropTable("dbo.PlayLists");
        }
    }
}
