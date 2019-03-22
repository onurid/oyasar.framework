using MongoDB.Bson.Serialization.Attributes;

namespace OYASAR.Framework.MongoDb.Model
{
	public class BsonModel<T> where T : class
	{
		[BsonId]
		public int Id { get; set; }
			
		public T Data { get; set; }
	}
}
