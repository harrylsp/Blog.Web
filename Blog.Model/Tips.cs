using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 前台公告
    /// </summary>
    public class Tips : BaseModel
    {
        /// <summary>
        /// 公告显示的颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 公告文本内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 公告中带有的链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 链接显示的文本
        /// </summary>
        public string UrlTips { get; set; }

        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime CreateTime { get; set; }

        public EStatus Status { get; set; }
    }
}
