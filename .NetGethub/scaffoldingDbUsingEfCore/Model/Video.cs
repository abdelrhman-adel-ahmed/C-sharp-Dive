using System;
using System.Collections.Generic;

#nullable disable

namespace scaffoldingDbUsingEfCore.Model
{
    public partial class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? PlayListId { get; set; }

        public virtual PlayList PlayList { get; set; }
    }
}
