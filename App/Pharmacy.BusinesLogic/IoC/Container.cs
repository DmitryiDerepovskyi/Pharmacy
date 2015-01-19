using Microsoft.Practices.Unity;
using Pharmacy.BusinesLogic.Validators;
using Pharmacy.BusinessLogic.Validators;
using Pharmacy.Contracts;
using Pharmacy.Contracts.BusinessLogic;
using Pharmacy.Data;
using Pharmacy.Core;

namespace Pharmacy.BusinessLogic.IoC
{
    public static class Container
    {
        public static readonly IUnityContainer UnityContainer;

        static Container()
        {
            UnityContainer = new UnityContainer();
            UnityContainer
                .RegisterType(typeof(IRepository<>), typeof(Repository<>))
                .RegisterType<DataContext>(new ContainerControlledLifetimeManager())
                .RegisterType(typeof(IValidator<MedcinePriceHistory>), typeof(MedcinePriceHistoryValidator))
                .RegisterType(typeof(IValidator<Medcine>), typeof(MedcineValidator))
                .RegisterType(typeof(IValidator<OrderDetails>), typeof(OrderDetailsValidator))
                .RegisterType(typeof(IValidator<Core.Pharmacy>), typeof(PharmacyValidator))
                .RegisterType(typeof(IValidator<Storage>), typeof(StorageValidator))
                .RegisterType(typeof(IValidator<Order>), typeof(OrderValidator));
        }
    }
}
