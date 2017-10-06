using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IDeleteService<T> where T : EntityDTO
    {
        void Delete(T entity);
    }
}
