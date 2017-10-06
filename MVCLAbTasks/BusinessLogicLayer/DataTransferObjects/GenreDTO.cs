using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class GenreDTO: EntityDTO
    {
        public string Name { get; set; }
        public string GenreParentName { get; set; }
    }
}
