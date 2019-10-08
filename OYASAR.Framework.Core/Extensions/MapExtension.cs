using System.Linq;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Utils;

namespace OYASAR.Framework.Core.Extensions
{
    public static class MapExtension
    {
        public static T MapTo<T>(this object model)
        {
            var mapper = Invoke<IMapper>.Call();
            return mapper.Map<T>(model);
        }

        public static IQueryable<T> MapTo<T>(this IQueryable model)
        {
            var mapper = Invoke<IMapper>.Call();
            return mapper.Map<T>(model);
        }
    }
}
