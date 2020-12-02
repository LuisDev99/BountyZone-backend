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

        ServiceResult<T> Delete(int entityID);

        ServiceResult<T> Update(T data);

        ServiceResult<T> Patch(T data);
    }
}
