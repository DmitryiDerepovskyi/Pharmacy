using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinessLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Services
{
    public class ServiceOrder : IService<Order>
    {
        private readonly IRepository<Order> _repository;
        private readonly IValidator<Order> _validator;

        public ServiceOrder()
        {
            _validator = Container.UnityContainer.Resolve<IValidator<Order>>();
            _repository = Container.UnityContainer.Resolve<IRepository<Order>>();
        }

        public void Add(Order entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(Order entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(Order entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<Order> GetAll()
        {
            return _repository.GetAll();
        }

        public Order GetByPrimaryKey(int key)
        {
            return _repository.GetByPrimaryKey(key);
        }
    }
}
