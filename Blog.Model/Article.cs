using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    public class Article : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public string Remark { get; set; }

        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime CreateTime { get; set; }

        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime ReviseTime { get; set; }

        public EStatus Status { get; set; }

    }
}
