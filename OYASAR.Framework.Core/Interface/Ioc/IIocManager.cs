namespace OYASAR.Framework.Core.Interface
{
    public interface IIocManager : IIocRegistrar, IIocResolver
    {
        void Initialize();
    }
}
