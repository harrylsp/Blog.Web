using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 留言墙
    /// </summary>
    public class MessageWall : BaseModel
    {
        /// <summary>
        /// 留言(回复)人
        /// </summary>
        public string Publiser { get; set; }

        /// <summary>
        /// 留言(回复)内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 留言(回复)时间
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 留言Id
        /// </summary>
        public string ParentId { get; set; }
    }
}
