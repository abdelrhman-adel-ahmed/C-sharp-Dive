using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFramework_2
{

    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<PlayList> MyPlayLists { get; set; }



    }
    class PlayList
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<Video> PlayListVideos { get; set; }

        public override string ToString()
        {
            string play_lists = "";
            foreach (var item in PlayListVideos)
            {
                play_lists += item.Title;
            }
            return play_lists;
        }
    }

    class MeContext : DbContext
    {
        public MeContext() : base(@"Data Source=.;Initial Catalog=SecondDB;Integrated Security=True") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MeContext, EntityFramework_2.Migrations.Configuration>());

        }

        //the pipeline to the database any things that get added here represent tables
        public DbSet<Video> Videos { get; set; }
        public DbSet<PlayList> PlayList { get; set; }

    }
    class many_to_many
    {
        public static void run()
        {
            var db = new MeContext();

            //clear the tables
            
            //db.PlayList.RemoveRange(db.PlayList);
            //db.Videos.RemoveRange(db.Videos);
            Video v1 = new Video
            {
                Title = "hello entity",
                Description = "ooooh"
            };
            Console.WriteLine(v1);
            Video v2 = new Video
            {
                Title = "hello entity 2",
                Description = "ooooh2"
            };

            db.Videos.Add(v1);
            db.Videos.Add(v2);

            PlayList playlist1 = new PlayList();
            playlist1.Title = "first play list";

            PlayList playlist2 = new PlayList();
            playlist2.Title = "second play list";

            playlist1.PlayListVideos = new List<Video> { v1 };
            playlist2.PlayListVideos = new List<Video> { v1 };

            db.PlayList.Add(playlist1);
            db.PlayList.Add(playlist2);

            db.SaveChanges();
        }


    }
}
