using System.Collections.Generic;
using DataAccessLayer.Entities.AbstractEntities;

namespace DataAccessLayer.Entities
{

    public class PlatformType:Entity
    {
        public string Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
