using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICommentService: ICreateService<CommentDTO>
    {
        ICollection<CommentDTO> GetGameComments(GameDTO game);
    }
}
