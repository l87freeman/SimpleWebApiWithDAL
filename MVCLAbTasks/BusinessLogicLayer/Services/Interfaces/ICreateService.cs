using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICreateService<in T> where T:EntityDTO
    {
        void Create(T entity);
    }
}
