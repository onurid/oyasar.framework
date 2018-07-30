using OYASAR.Framework.Core.Manager;

namespace OYASAR.Framework.Core.Utils
{
    public static class Invoke<T> where T : class
    {
        public static T Call()
        {
            return IocManager.Instance.Resolve<T>();
        }
    }
}
