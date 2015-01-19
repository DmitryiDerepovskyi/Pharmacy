using System;
using System.Linq;
using System.Linq.Expressions;
using Pharmacy.Contracts.Entities;

namespace Pharmacy.Contracts.BusinessLogic
{
    public interface IService<T> where T : class, IDbEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
    }
}
