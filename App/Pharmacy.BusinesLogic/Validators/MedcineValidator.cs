﻿using System;
using System.Text.RegularExpressions;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Validators
{
    public class MedcineValidator : IValidator<Medcine>
    {
        private readonly IRepository<Medcine> _repository; 

        public MedcineValidator(IRepository<Medcine> repository) {
            _repository = repository;
        }

        public bool IsValid(Medcine entity) {
            return !String.IsNullOrEmpty(entity.Name)
                && Regex.IsMatch(entity.SerialNumber, @"...-...-..")
                && entity.Price > 0;
        }

        public bool IsExists(object key)
        {
            return _repository.GetByPrimaryKey(key) != null;
        }
    }
}
