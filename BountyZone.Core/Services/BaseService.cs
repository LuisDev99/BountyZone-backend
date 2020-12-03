using BountyZone.Core.Helpers;
using BountyZone.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BountyZone.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public ServiceResult<T> Create(T data)
        {
            try
            {
                var newEntity = _repository.Add(data);
                return ServiceResult<T>.SuccessResult(newEntity);
            } catch(Exception)
            {
                return ServiceResult<T>.ErrorResult($"Error while creating {nameof(T)} entity");
            }
        }

        public ServiceResult<IEnumerable<T>> GetAll()
        {
            var entities = _repository.GetAll();

            if (Validators.IsListNullOrEmpty(entities))
            {
                return ServiceResult<IEnumerable<T>>.NotFoundResult($"No {nameof(T)}s found");
            }

            return ServiceResult<IEnumerable<T>>.SuccessResult(entities);
        }

        public ServiceResult<T> GetByID(int entityID)
        {
            var entity = _repository.GetByID(entityID);

            if (entity == null)
            {
                return ServiceResult<T>.NotFoundResult($"Entity {nameof(T)} with ID {entityID} was not found");
            }

            return ServiceResult<T>.SuccessResult(entity);
        }

        public ServiceResult<T> Delete(T entity)
        {
            try
            {
                _repository.Delete(entity);
                return ServiceResult<T>.SuccessResult(entity);
            } catch(Exception)
            {
                return ServiceResult<T>.ErrorResult($"Unable to delete {nameof(T)} entity");
            }
        }        

        public ServiceResult<T> Update(T entity)
        {
            try
            {
                _repository.Update(entity);
                return ServiceResult<T>.SuccessResult(entity);
            } catch(Exception)
            {
                return ServiceResult<T>.ErrorResult($"Unable to update {nameof(T)} entity");
            }
        }

        public ServiceResult<T> Patch<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression)
        {
            try
            {
                _repository.Patch(entity, propertyExpression);
                return ServiceResult<T>.SuccessResult(entity);
            }
            catch (Exception)
            {
                return ServiceResult<T>.ErrorResult($"Unable to update properties for {nameof(T)} entity");
            }
        }
    }
}
