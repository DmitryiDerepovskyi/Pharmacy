using System;
using System.Security.Policy;
using Pharmacy.BusinesLogic.Services;

namespace Pharmacy.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServicePharmacy();
            var all = service.GetAll();
            foreach (var p in all)
            {
                Console.WriteLine(p.Address);
            }
        }
    }
}
