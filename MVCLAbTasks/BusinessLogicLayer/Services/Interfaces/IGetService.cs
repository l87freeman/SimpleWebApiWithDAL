using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects.AbstractEntities;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IGetService<T> where T : EntityDTO
    {
        T Get<TKey>(TKey id);
        ICollection<T> GetAll();
    }
}
