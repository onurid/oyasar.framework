using System;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class CreatedAuditEntity<TId> : BaseAudit<TId>
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
