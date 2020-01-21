using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    public class CategoryView
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EBoolStatus Status { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
