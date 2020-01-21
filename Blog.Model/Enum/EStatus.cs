using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    [EnumAsInt]
    public enum EStatus
    {
        正常 = 0,
        禁用 = 1,
        删除 = 2
    }
}
