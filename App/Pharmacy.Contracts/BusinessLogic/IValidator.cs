using Pharmacy.Contracts.Entities;

namespace Pharmacy.Contracts.BusinessLogic
{
    public interface IValidator<T> where T: class, IDbEntity
    {
        bool IsValid(T entity);
        bool IsExist(T entity);
    }
}
