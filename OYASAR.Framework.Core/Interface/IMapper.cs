using System;
using System.Linq;
using System.Linq.Expressions;

namespace OYASAR.Framework.Core.Interface
{
    public interface IMapper
    {
        T Map<T>(object dto);
        IQueryable<T> Map<T>(IQueryable query);

        void RegisterMap<T, K>();
        void RegisterMap<T, K>(T model, K dto, Expression<Func<T, K>> expr);
    }
}
