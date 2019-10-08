
#if NET451
using System.Web;
#endif

//#if NETSTANDARD1_3
//using Microsoft.AspNetCore.Http;
//#endif

namespace OYASAR.Framework.Utils.Manager
{
    //#if NETSTANDARD1_3
    //    public class SessionManager : ISessionManager
    //    {
    //        private const string Key = "Key";
    //        private readonly ISession Session;

    //        public SessionManager(ISession Session)
    //        {
    //            this.Session = Session;
    //        }

    //        public T GetIdentity<T>()
    //        {
    //            //if (Session.IsAvailable)

    //            //var result = Session.TryGetValue(Key, out byte[] value);
    //            // if (result)
    //            //var jsonStr = Session.Keys.ToList().Single(x => x == Key);
    //            Session.TryGetValue(Key, out byte[] value);
    //            var jsonStr = value.ToString();

    //            return JsonHelper.Deserialize<T>(jsonStr);
    //        }

    //        public void CreateIdentity<T>(T identity)
    //        {
    //            //if (Session.IsAvailable)

    //            var jsonStr = JsonHelper.Serialize(identity);
    //            var bytes = Encoding.UTF8.GetBytes(jsonStr);
    //            Session.Set(Key, bytes);
    //        }

    //        public void RemoveIdentity()
    //        {
    //            Session.Clear();
    //        }

    //        public void SetTimeout(int timeout)
    //        {

    //        }
    //    }

    //    public interface ISessionManager
    //    {
    //        T GetIdentity<T>();
    //        void CreateIdentity<T>(T identity);
    //        void RemoveIdentity();
    //    }


    //#endif

#if NET451
    public static class SessionManager
    {
        private const string Key = "Key";
        
        public static T GetIdentity<T>()
        {
            return (T)HttpContext.Current.Session[Key];
        }
        
        public static void CreateIdentity<T>(T identity)
        {
            HttpContext.Current.Session[Key] = identity;
        }
        
        public static void RemoveIdentity()
        {
            HttpContext.Current.Session.Clear();
        }
        
        public static void SetTimeout(int timeout)
        {
            HttpContext.Current.Session.Timeout = timeout;
        }
    }
#endif
}
