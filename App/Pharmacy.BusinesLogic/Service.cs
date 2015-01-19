using System.Linq;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Contracts.Entities;
using Pharmacy.BusinesLogic.IoC;
namespace Pharmacy.BusinesLogic
{
    public class Service<T> : IService<T> where T : class, IDbEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;

        public Service(IValidator<T> validator, IRepository<T> repository)
        {
          //  var _validator = Container.UnityContainer.Resolve<IValidator<Core.Pharmacy>>();
            _repository = repository;
        }

        public void Add(T entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            if (_validator.IsExist(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            if (_validator.IsExist(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
