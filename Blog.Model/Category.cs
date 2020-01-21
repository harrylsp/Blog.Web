using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    public class Category : BaseModel
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EStatus Status { get; set; }

        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime CreateTime { get; set; }
    }
}
