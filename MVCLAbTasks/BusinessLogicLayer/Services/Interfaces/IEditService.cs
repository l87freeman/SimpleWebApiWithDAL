using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IEditService<in T> where T : EntityDTO
    {
        void Update(T entity);
    }
}
