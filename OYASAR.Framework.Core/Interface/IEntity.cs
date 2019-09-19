namespace OYASAR.Framework.Core.Interface
{
    public interface IEntity<TId> : IEntity
    {
        TId Id { get; }

        void SetId(TId id);
    }

    public interface IEntity { }
}