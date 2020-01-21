using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 资源分享
    /// </summary>
    public class ResourceSharing : BaseModel
    {
        /// <summary>
        /// 链接Url
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片Url
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 1源码 2工具 3电子书
        /// </summary>
        public int RescourceType { get; set; }
    }
}
