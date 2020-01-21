using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 时光轴
    /// </summary>
    public class TimeAxis : BaseModel
    {
        /// <summary>
        /// 事件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime OccurTime { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        
    }
}
