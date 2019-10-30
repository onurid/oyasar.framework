using System;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class CreateAuditEntity<TId> : BaseAudit<TId>
    {
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
