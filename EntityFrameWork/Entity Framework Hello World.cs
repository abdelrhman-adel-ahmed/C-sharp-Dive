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
        public DbSet<Video> Viedos{get;set;}
        public DbSet<PlayList> PlayList { get; set; }

    }
    class Entity_Framework_Hello_World
    {

        public static void run()
        {
            Video v1 = new Video
            {
                Title = "hello entity",
                Description = "ooooh"
            };
            var mycontext = new MeContext();
            mycontext.Viedos.Add(v1);
            PlayList playlist = new PlayList();
            playlist.Title = "first play list";
            playlist.PlayListVideo.Add(v1);
            mycontext.SaveChanges();
            
        }

    }
}
