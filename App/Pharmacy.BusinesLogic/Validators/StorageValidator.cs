
using System.Linq;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Validators
{
    public class StorageValidator : IValidator<Storage>
    {
        private readonly IRepository<Storage> _repository;
        private readonly IValidator<Medcine> _medcineValidator;
        private readonly IValidator<Core.Pharmacy> _pharmacyValidator;

        public StorageValidator(IRepository<Storage> repository,
            IValidator<Medcine> medcineValidator,
            IValidator<Core.Pharmacy> pharmacyValidator)
        {
            _repository = repository;
            _medcineValidator = medcineValidator;
            _pharmacyValidator = pharmacyValidator;
        }

        public bool IsValid(Storage entity)
        {
            return _medcineValidator.IsExists(entity.MedcineId)
                   && _pharmacyValidator.IsExists(entity.PharmacyId)
                   && entity.MedcineId == entity.Medcine.Id
                   && entity.PharmacyId == entity.Pharmacy.Id;
        }

        public bool IsExists(object obj)
        {
            var entity = obj as Storage;
            if (entity == null)
                return false;
            return _repository.Find(storage => (storage.MedcineId == entity.MedcineId && storage.PharmacyId == entity.PharmacyId)).Count<Storage>() == 1;
        }
    }
}
