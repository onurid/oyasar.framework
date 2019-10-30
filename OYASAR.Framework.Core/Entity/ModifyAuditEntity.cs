using System;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class ModifyAuditEntity<TId> : CreateAuditEntity<TId>
    {
        public int? ModifiedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
