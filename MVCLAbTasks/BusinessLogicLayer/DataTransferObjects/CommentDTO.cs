using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CommentDTO: EntityDTO
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }

        public int? ParentCommentId { get; set; }
        public string GameKey { get; set; }
    }
}
