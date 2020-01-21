using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common
{
    /// <summary>
    /// 分页实体
    /// </summary>
    public class PageData
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 数据列表
        /// </summary>
        public dynamic data { get; set; }
    }
}
