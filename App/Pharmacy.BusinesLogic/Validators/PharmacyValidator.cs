using System;
using System.Linq;
using Microsoft.Practices.Unity;
using Pharmacy.BusinesLogic.IoC;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;

namespace Pharmacy.BusinesLogic.Validators
{
    public class PharmacyValidator : IValidator<Core.Pharmacy>
    {
        private readonly IRepository<Core.Pharmacy> _repository;

        public PharmacyValidator()
        {
            _repository = Container.UnityContainer.Resolve<IRepository<Core.Pharmacy>>();
        }

        public bool IsValid(Core.Pharmacy entity)
        {
            var validity = !String.IsNullOrEmpty(entity.Address)
                   && !String.IsNullOrEmpty(entity.PhoneNumber)
                   && entity.Number > 0;

            foreach (var pharmacy in _repository.GetAll().ToList())
            {
                if (!validity) break;
                if (pharmacy.Address == entity.Address
                    && pharmacy.PhoneNumber == entity.PhoneNumber
                    && pharmacy.Number == entity.Number)
                    validity = false;
            }

            return validity;
        }

        public bool IsExist(Core.Pharmacy entity)
        {
            return _repository.GetByPrimaryKey(entity.Id) != null;
        }
    }
}
