using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class GameDTO: EntityDTO
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<PlatformTypeDTO> PlatformTypes { get; set; }
    }
}
