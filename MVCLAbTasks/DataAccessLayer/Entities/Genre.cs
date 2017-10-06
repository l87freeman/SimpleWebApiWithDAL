using System.Collections.Generic;
using DataAccessLayer.Entities.AbstractEntities;

namespace DataAccessLayer.Entities
{
    public class Genre:Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public string GenreParentName { get; set; }
        public virtual Genre SubGenre { get; set; }
    }
}
