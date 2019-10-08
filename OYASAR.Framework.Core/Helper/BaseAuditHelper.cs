using System;
using OYASAR.Framework.Core.Entity;

namespace OYASAR.Framework.Core.Helper
{
#if (NET451 || NETSTANDARD1_3 || NET35)
    public class BaseAuditHelper<TDataObject, TId>
    {
        public int SystemUserId { get; set; } = 1;

        public enum BaseAuditType
        {
            Create = 0,
            Modify = 1,
            Delete
        }

        public BaseAuditHelper(TDataObject dataObject, BaseAuditType baseAuditType, bool isNew = false)
        {
            if (TypeHelper.IsAssignableFrom(typeof(TDataObject), typeof(ModifiedAuditEntity<TId>)) && baseAuditType == BaseAuditType.Modify)
            {
                var modifyData = dataObject as ModifiedAuditEntity<TId>;
                modifyData.ModifiedDate = DateTime.Today;
                modifyData.ModifiedBy = SystemUserId;
                if (isNew)
                {
                    modifyData.CreatedDate = DateTime.Today;
                    modifyData.CreatedBy = SystemUserId;
                }
            }

            if (TypeHelper.IsAssignableFrom(typeof(TDataObject), typeof(CreatedAuditEntity<TId>)) && baseAuditType == BaseAuditType.Create && isNew)
            {
                var modifyData = dataObject as CreatedAuditEntity<TId>;
                modifyData.CreatedDate = DateTime.Today;
                modifyData.CreatedBy = SystemUserId;
            }

            if (TypeHelper.IsAssignableFrom(typeof(TDataObject), typeof(DeletedAuditEntity<TId>)) && baseAuditType == BaseAuditType.Delete)
            {
                var modifyData = dataObject as DeletedAuditEntity<TId>;
                modifyData.DeletedDate = DateTime.Today;
                modifyData.DeletedBy = SystemUserId;
            }
        }
    }
#endif
}
