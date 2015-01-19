using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinessLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Services
{
    public class ServiceMedcine : IService<Medcine>
    {
        private readonly IRepository<Medcine> _repository;
        private readonly IValidator<Medcine> _validator;

        public ServiceMedcine()
        {
            _validator = Container.UnityContainer.Resolve<IValidator<Medcine>>();
            _repository = Container.UnityContainer.Resolve<IRepository<Medcine>>();
        }

        public void Add(Medcine entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(Medcine entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(Medcine entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<Medcine> GetAll()
        {
            return _repository.GetAll();
        }

        public Medcine GetByPrimaryKey(int key)
        {
            return _repository.GetByPrimaryKey(key);
        }
    }
}
