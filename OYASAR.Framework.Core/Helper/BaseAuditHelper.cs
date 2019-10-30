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
            if (TypeHelper.IsAssignableFrom(typeof(TDataObject), typeof(ModifyAuditEntity<TId>)) && baseAuditType == BaseAuditType.Modify)
            {
                var modifyData = dataObject as ModifyAuditEntity<TId>;
                modifyData.ModifyDate = DateTime.Today;
                modifyData.ModifiedBy = SystemUserId;
                if (isNew)
                {
                    modifyData.CreateDate = DateTime.Today;
                    modifyData.CreatedBy = SystemUserId;
                }
            }

            if (TypeHelper.IsAssignableFrom(typeof(TDataObject), typeof(CreateAuditEntity<TId>)) && baseAuditType == BaseAuditType.Create && isNew)
            {
                var modifyData = dataObject as CreateAuditEntity<TId>;
                modifyData.CreateDate = DateTime.Today;
                modifyData.CreatedBy = SystemUserId;
            }

            if (TypeHelper.IsAssignableFrom(typeof(TDataObject), typeof(DeleteAuditEntity<TId>)) && baseAuditType == BaseAuditType.Delete)
            {
                var modifyData = dataObject as DeleteAuditEntity<TId>;
                modifyData.DeleteDate = DateTime.Today;
                modifyData.DeletedBy = SystemUserId;
            }
        }
    }
#endif
}
