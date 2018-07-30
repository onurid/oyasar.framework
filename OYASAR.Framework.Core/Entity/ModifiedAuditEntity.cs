using System;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class ModifiedAuditEntity<TId> : CreatedAuditEntity<TId>
    {
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
