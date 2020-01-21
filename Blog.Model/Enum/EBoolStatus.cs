using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    [EnumAsInt]
    public enum EBoolStatus
    {
        否 = 0,
        是 = 1
    }
}
