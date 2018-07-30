using Castle.Windsor;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.CastleWindsor
{
    public interface IWindsorIocManger : IIocManager, IWindsorIocResolver
    {
        IWindsorContainer Container { get; }
    }
}