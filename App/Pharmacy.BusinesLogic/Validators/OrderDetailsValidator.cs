using System.Linq;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.Validators
{
    public class OrderDetailsValidator : IValidator<OrderDetails>
    {
        private readonly IRepository<OrderDetails> _repository;
        private readonly IValidator<Order> _orderValidator;
        private readonly IValidator<Medcine> _medcineValidator;

        public OrderDetailsValidator(IRepository<OrderDetails> repository,
            IValidator<Order> orderValidator,
            IValidator<Medcine> medcineValidator)
        {
            _repository = repository;
            _orderValidator = orderValidator;
            _medcineValidator = medcineValidator;
        }

        public bool IsValid(OrderDetails entity)
        {
            return _orderValidator.IsExists(entity.OrderId)
                   && _medcineValidator.IsExists(entity.MedcineId)
                   && entity.MedcineId == entity.Medcine.Id
                   && entity.OrderId == entity.Order.Id
                   && entity.UnitPrice > 0
                   && entity.Count > 0;
        }
        public bool IsExists(object key)
        {
            var entity = key as OrderDetails;
            if (entity == null)
                return false;
            return _repository.Find(od => (od.MedcineId == entity.MedcineId && od.OrderId == entity.OrderId)).Count<OrderDetails>() == 1;
        }
    }
}
