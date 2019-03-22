using MongoDB.Bson;
using MongoDB.Driver;
using OYASAR.Framework.Core.CustomType;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.MongoDb.Model;
using System.Collections.Generic;
using System.Linq;

namespace OYASAR.Framework.MongoDb.CustomType
{
	public class NoSqlDataType<T> : NoSqlDataType, INoSqlDataType<T> where T : class
	{
		public IEnumerable<T> ToFind()
		{
			var collection = (MongoCollection<BsonModel<T>>) Data;
			
			IEnumerable<BsonModel<T>> result = collection.FindAll();

			IList<T> list = new List<T>();

			var text = result.ToJson();

		    result.ToList().ForEach(x => list.Add(x.Data));

			return list;
		}

		public T ToFilter(int id)
		{
			var collection = (MongoCollection<BsonModel<T>>)Data;

			var result = collection.FindOneById(id);

			return result.Data;
		}
	}
}
