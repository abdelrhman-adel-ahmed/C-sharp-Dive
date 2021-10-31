using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    // each class represet a relation (table) and the properties inside the class represend the (attributes )
    
    class PlayList
    {
        public int ID { get; set; }
        public string Title { get; set; }

        //one to many relation with viedo , because we declare it (as list) 
        public List<Video> PlayListVideo { get; set; }
    }
    class Video
    { 
       public int ID { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
    }

    class MeContext : DbContext
    {
        public MeContext() : base(@"Data Source=.;Initial Catalog=FirstDB;Integrated Security=True") { }

        //the pipeline to the database any things that get added here represent tables
        public DbSet<Video> Videos{get;set;}
        public DbSet<PlayList> PlayList { get; set; } 

    } 
    class Entity_Framework_Hello_World
    {

        public static void run()
        {
            var db = new MeContext();
            //db.Videos.Select(v => v.Title).ToList().ForEach(Console.WriteLine);
            //return;
            //by diffult the entity framework doesnot perform the join untill you till it to ,because you may
            //not need the data from the other table (lazy loading)
            PlayList thelist = db.PlayList.Include(list => list.PlayListVideo).Single();
            foreach (var video in thelist.PlayListVideo)
            {
                Console.WriteLine(video.Title);
            }
            return;
            db.Videos.RemoveRange(db.Videos);
            db.PlayList.RemoveRange(db.PlayList);
            Video v1 = new Video
            {
                Title = "hello entity",
                Description = "ooooh"
            };
            Video v2 = new Video
            {
                Title = "hello entity 2",
                Description = "ooooh2"
            };

            db.Videos.Add(v1);
            db.Videos.Add(v2);

            PlayList playlist = new PlayList();
            playlist.Title = "first play list";
            playlist.PlayListVideo = new List<Video> { v1,v2 };
            db.PlayList.Add(playlist);
            db.SaveChanges();
            
        }

    }
}
