using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLAbTasks.Models.Entities
{
    public class CommentView
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }

        public int? ParentCommentId { get; set; }
        public string GameKey { get; set; }
    }
}