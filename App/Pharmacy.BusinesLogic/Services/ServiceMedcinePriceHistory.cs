using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinessLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Services
{
    public class ServiceMedcinePriceHistory : IService<MedcinePriceHistory>
    {
        private readonly IRepository<MedcinePriceHistory> _repository;
        private readonly IValidator<MedcinePriceHistory> _validator;

        public ServiceMedcinePriceHistory()
        {
            _validator = Container.UnityContainer.Resolve<IValidator<MedcinePriceHistory>>();
            _repository = Container.UnityContainer.Resolve<IRepository<MedcinePriceHistory>>();
        }

        public void Add(MedcinePriceHistory entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(MedcinePriceHistory entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(MedcinePriceHistory entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<MedcinePriceHistory> GetAll()
        {
            return _repository.GetAll();
        }

        public MedcinePriceHistory GetByPrimaryKey(int key)
        {
            return _repository.GetByPrimaryKey(key);
        }
    }
}
