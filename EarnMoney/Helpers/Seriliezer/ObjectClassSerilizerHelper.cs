using Newtonsoft.Json;

namespace EarnMoney.Helpers.Seriliazer
{
    public static class ObjectClassSerilizerHelper
    {
        public static string ToStringClass(this object obj)
        {
			try
			{
                if (obj == null) return "";
                return JsonConvert.SerializeObject(obj.ToString());
            }
            catch (Exception)
			{
                return "";
			}
        }
    }
}
