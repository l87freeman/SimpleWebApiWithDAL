using System.Collections.Generic;
using DataAccessLayer.Entities.AbstractEntities;

namespace DataAccessLayer.Entities
{
    public class Game:Entity
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<PlatformType> PlatformTypes { get; set; }
    }
}
