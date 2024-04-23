using Newtonsoft.Json;

namespace Shopping_Tutorial.Repository
{
	public static class SessionExtensions
	{
		// this ở đây dùng để định nghĩa 1 pt mở rộng
		public static void SetJson(this ISession session, string key, object value)
		{
			// lưu trữ dưới dạng key-value và convert sang json
			session.SetString(key, JsonConvert.SerializeObject(value));
		}
		// generic 
		public static T? GetJson<T>(this ISession session, string key)
		{
			var sessionData = session.GetString(key);
			return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
		}
	}
}
