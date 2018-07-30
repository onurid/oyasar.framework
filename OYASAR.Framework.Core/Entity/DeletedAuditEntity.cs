using System;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class DeletedAuditEntity<TId> : ModifiedAuditEntity<TId>
    {
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
