﻿using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinessLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;

namespace Pharmacy.BusinessLogic.Services
{
    public class ServicePharmacy : IService<Core.Pharmacy>
    {
        private readonly IRepository<Core.Pharmacy> _repository;
        private readonly IValidator<Core.Pharmacy> _validator;

        public ServicePharmacy()
        {
            _validator = Container.UnityContainer.Resolve<IValidator<Core.Pharmacy>>();
            _repository = Container.UnityContainer.Resolve<IRepository<Core.Pharmacy>>();
        }

        public void Add(Core.Pharmacy entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
                _repository.SaveChanges();
            }
        }

        public void Remove(Core.Pharmacy entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }

        public void Update(Core.Pharmacy entity)
        {
            if (_validator.IsExists(entity))
            {
                _repository.SaveChanges();
            }
        }

        public IQueryable<Core.Pharmacy> GetAll()
        {
            return _repository.GetAll();
        }

        public Core.Pharmacy GetByPrimaryKey(int key)
        {
            return _repository.GetByPrimaryKey(key);
        }
    }
}
