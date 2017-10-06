using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLAbTasks.Models.Entities
{
    public class GameView
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CommentView> Comments { get; set; }
        public ICollection<GenreView> Genres { get; set; }
        public ICollection<PlatformTypeView> PlatformTypes { get; set; }
    }
}