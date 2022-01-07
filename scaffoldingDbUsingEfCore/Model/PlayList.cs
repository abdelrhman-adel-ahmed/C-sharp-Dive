using System;
using System.Collections.Generic;

#nullable disable

namespace scaffoldingDbUsingEfCore.Model
{
    public partial class PlayList
    {
        public PlayList()
        {
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
