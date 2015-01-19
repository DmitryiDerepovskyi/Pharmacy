using System;
using Pharmacy.BusinessLogic.Services;
using Pharmacy.Core;

namespace Pharmacy.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServicePharmacy();
            service.Add(new Core.Pharmacy()
            {
                Address = "City1",
                Number = 1,
                PhoneNumber = "000 000 00 00",
                OpenDate = DateTime.Now
            });
            var all = service.GetAll();
            foreach (var s in all)
            {
                Console.WriteLine(s.OpenDate);
            }
            var med = new ServiceMedcine();
            med.Add(new Medcine()
            {
                Name = "name1",
                Description = "dqwe",
                Price = 1000,
                SerialNumber = "000-000-00"
            });
            var allMed = med.GetAll();
            foreach (var m in allMed)
            {
                Console.WriteLine(m.Name);
            }
        }
    }
}
