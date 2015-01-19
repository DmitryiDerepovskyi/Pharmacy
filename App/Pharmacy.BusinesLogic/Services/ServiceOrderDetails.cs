using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinessLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Services
{
    public class ServiceOrderDetails : IService<OrderDetails>
    {
        private readonly IRepository<OrderDetails> _repository;
        private readonly IValidator<OrderDetails> _validator;

        public ServiceOrderDetails()
        {
            _validator = Container.UnityContainer.Resolve<IValidator<OrderDetails>>();
            _repository = Container.UnityContainer.Resolve<IRepository<OrderDetails>>();
        }

        public void Add(OrderDetails entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(OrderDetails entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(OrderDetails entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<OrderDetails> GetAll()
        {
            return _repository.GetAll();
        }

        public OrderDetails GetByPrimaryKey(OrderDetails entity)
        {
            return _repository.Find(od => (od.MedcineId == entity.MedcineId && od.OrderId == entity.OrderId)).First<OrderDetails>();
        }
    }
}
