
using Pharmacy.Contracts.Entities;
namespace Pharmacy.Core
{
    public abstract class BaseEntity : IDbEntity
    {
        public virtual int Id { get; private set; }
    }
}
