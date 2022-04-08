namespace Manager.Core.Extensions
{
    public static class ExtensionMethods
    {
        public static bool IsIdValid(this long? id)
        {
            try
            {
                return id != null && id >= 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsIdValid(this long id)
        {
            try
            {
                return id >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}