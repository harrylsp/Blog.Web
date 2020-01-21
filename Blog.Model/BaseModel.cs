using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    public class BaseModel
    {
        /// <summary>
        /// Guid转成Mysql的无横线字符串
        /// </summary>
        [StringLength(32)]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
    }
}
