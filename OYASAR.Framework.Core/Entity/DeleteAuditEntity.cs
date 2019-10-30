using System;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class DeleteAuditEntity<TId> : ModifyAuditEntity<TId>
    {
        public int? DeletedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
