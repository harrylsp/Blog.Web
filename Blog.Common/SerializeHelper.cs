using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] SerializeToByte(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return Encoding.UTF8.GetBytes(jsonString);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEntity Deserialize<TEntity>(byte[] value)
        {
            if (value == null)
            {
                return default(TEntity);
            }

            var jsonString = Encoding.UTF8.GetString(value);

            return JsonConvert.DeserializeObject<TEntity>(jsonString);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializeToString(object item)
        {
            // 时间格式化
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            //直接使用  JsonConvert.SerializeObject(item)序列化，可能会得到一些 \r\n 之类的多余字符
            //Formatting.Indented 因为生成带有 \r\n 之类的换行符， 生成良好的显示格式,可读性更好
            // 在浏览器的Response查看请求返回的数据时，返回的json已经是格式化好的
            //另一方面,Formatting.None 不会生成\r\n 之类的字符， 会跳过不必要的空格和换行符
            var jsonString = JsonConvert.SerializeObject(item, Formatting.None, timeFormat);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
