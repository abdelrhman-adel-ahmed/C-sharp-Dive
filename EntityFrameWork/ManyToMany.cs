using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_manyto_many
{

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
        public MeContext() : base(@"Data Source=.;Initial Catalog=SecondDB;Integrated Security=True") { }

        //the pipeline to the database any things that get added here represent tables
        public DbSet<Video> Videos { get; set; }
        public DbSet<PlayList> PlayList { get; set; }

    }
    class ManyToMany
    {

        public static void run()
        {
            var db = new MeContext();
            Video v1 = new Video
            {
                Title = "v1",
                Description = "v1 des"

            };
            PlayList p1 = new PlayList
            {
                Title = "playlist 1",
                PlayListVideo = new List<Video> { v1 }
            };
            PlayList p2 = new PlayList
            {
                Title = "playlist 2",
                PlayListVideo = new List<Video> { v1 }
            };
            db.PlayList.Add(p1);
            db.PlayList.Add(p2);
            db.SaveChanges();


        }
    }
}
