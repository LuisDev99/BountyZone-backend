using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces
{
    public interface IBaseService<T>
    {
        ServiceResult<IEnumerable<T>> GetAll();

        ServiceResult<T> GetByID(int entityID);

        ServiceResult<T> Create(T data);

        ServiceResult<T> Delete(T entity);

        ServiceResult<T> Update(T entity);

        ServiceResult<T> Patch(T entity);
    }
}
