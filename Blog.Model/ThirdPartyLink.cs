using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 第三方链接
    /// </summary>
    public class ThirdPartyLink : BaseModel
    {
        /// <summary>
        /// 链接Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 链接展示的图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 链接标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime CreateTime { get; set; }
    }
}
