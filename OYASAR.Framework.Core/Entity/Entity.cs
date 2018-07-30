using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Entity
{
    public abstract class Entity<TIdType> : IEntity<TIdType>
    {
        public TIdType Id { get; private set; }

        public void SetId(TIdType id)
        {
            Id = id;
        }
    }
}
