using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinessLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Services
{
    public class ServiceStorage : IService<Storage>
    {
        private readonly IRepository<Storage> _repository;
        private readonly IValidator<Storage> _validator;

        public ServiceStorage()
        {
            _validator = Container.UnityContainer.Resolve<IValidator<Storage>>();
            _repository = Container.UnityContainer.Resolve<IRepository<Storage>>();
        }

        public void Add(Storage entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(Storage entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(Storage entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<Storage> GetAll()
        {
            return _repository.GetAll();
        }

        public Storage GetByPrimaryKey(Storage entity)
        {
            return _repository.Find(storage => (storage.MedcineId == entity.MedcineId && storage.PharmacyId == entity.PharmacyId)).First<Storage>();
        }
    }
}
