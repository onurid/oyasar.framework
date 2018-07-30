namespace OYASAR.Framework.Core.Interface
{
    public interface IEntity<TId>
    {
        TId Id { get; }

        void SetId(TId id);
    }
}