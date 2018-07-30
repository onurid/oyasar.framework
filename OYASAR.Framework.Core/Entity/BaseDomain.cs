using static OYASAR.Framework.Core.Utils.Constants;

namespace OYASAR.Framework.Core.Entity
{
    public class BaseDomain<TId> : Entity<TId>
    {
        public BusinessObjectState State { get; set; }
    }
}
