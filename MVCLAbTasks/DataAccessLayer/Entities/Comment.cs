using DataAccessLayer.Entities.AbstractEntities;

namespace DataAccessLayer.Entities
{
    public class Comment:Entity
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }

        public int? ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }

        public string GameKey { get; set; }
        public virtual Game Game { get; set; }
    }
}
