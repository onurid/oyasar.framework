using System.Collections;

namespace OYASAR.Framework.Core.Helper
{
    public static class ValidationHelper
    {
        /// <summary>
        /// CheckId
        /// </summary>
        /// <param name="getValue"></param>
        public static bool CheckId(int getValue)
        {
            return getValue >= 1;
        }

        /// <summary>
        /// CheckId
        /// </summary>
        /// <param name="getValue"></param>
        public static bool CheckIsNull(object getValue)
        {
            return getValue == null;
        }

        /// <summary>
        /// CheckId
        /// </summary>
        /// <param name="getValue"></param>
        public static bool CheckIsNullOrEmpty(string getValue)
        {
            return string.IsNullOrEmpty(getValue);
        }

        /// <summary>
        /// CheckId
        /// </summary>
        /// <param name="getValue"></param>
        public static bool CheckListAny(IEnumerable getValue)
        {
            return getValue.GetEnumerator().MoveNext();
        }
    }
}