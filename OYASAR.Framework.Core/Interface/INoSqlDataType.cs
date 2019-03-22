using System.Collections.Generic;

namespace OYASAR.Framework.Core.Interface
{
    public interface INoSqlDataType
    {
        object Data { get; set; }
    }

    public interface INoSqlDataType<T> : INoSqlDataType where T : class
    {
        IEnumerable<T> ToFind();

        T ToFilter(int id);
    }
}
