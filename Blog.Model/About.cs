using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 关于
    /// </summary>
    public class About : BaseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 一句话介绍
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 关于类型 1关于博客 2关于作者
        /// </summary>
        public int AboutType { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime CreateTime { get; set; }

    }
}
