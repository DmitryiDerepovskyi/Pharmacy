﻿using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Contracts;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Validators
{
    public class OrderValidator : IValidator<Order>
    {
        private readonly IRepository<Order> _repository;
        private readonly IValidator<Core.Pharmacy> _validator;

        public OrderValidator(IRepository<Order> repository, IValidator<Core.Pharmacy> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public bool IsValid(Order entity)
        {
            return _validator.IsExists(entity.PharmacyId)
                   && entity.PharmacyId == entity.Pharmacy.Id;
        }

        public bool IsExists(object key)
        {
            return _repository.GetByPrimaryKey(key) != null;
        }
    }
}
