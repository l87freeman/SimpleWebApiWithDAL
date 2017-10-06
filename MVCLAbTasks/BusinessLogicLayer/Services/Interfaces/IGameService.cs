using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IGameService: ICreateService<GameDTO>, IEditService<GameDTO>, IGetService<GameDTO>, IDeleteService<GameDTO>
    {
        ICollection<GameDTO> GetGamesByGanre(GenreDTO genre);
        ICollection<GameDTO> GetGamesByPlatfornType(PlatformTypeDTO platformType);
    }
}
