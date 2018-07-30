using System.IO;

namespace OYASAR.Framework.Utils.Helper
{
    public class XmlHelper
    {
        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            //XmlTextWriter tw = null;
            //try
            //{
            //    XmlSerializer serializer = new XmlSerializer(o.GetType());
            //    tw = new XmlTextWriter(sw);
            //    serializer.Serialize(tw, o);
            //}
            //catch (Exception ex)
            //{
                
            //}
            //finally
            //{
            //    sw.Close();
            //    if (tw != null)
            //    {
            //        tw.Close();
            //    }
            //}
            return sw.ToString();
        }
    }
}
