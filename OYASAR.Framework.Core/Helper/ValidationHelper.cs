namespace OYASAR.Framework.Core.Helper
{
    public static class ValidationHelper
    {
        /// <summary>
        /// CheckId
        /// </summary>
        /// <param name="getValue"></param>
        public static bool CheckId(object getValue)
        {
            return (int)getValue >= 1;
        }

        /// <summary>
        /// CheckId
        /// </summary>
        /// <param name="getValue"></param>
        public static bool CheckIsNUll(object getValue)
        {
            return getValue == null;
        }
    }
}