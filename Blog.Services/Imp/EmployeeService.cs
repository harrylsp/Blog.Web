using System;
using System.Collections.Generic;
using System.Text;
using Blog.DataAccess;
using Blog.Model;
using ServiceStack.OrmLite;

namespace Blog.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly BlogDatabase _db;

        public EmployeeService(BlogDatabase db)
        {
            _db = db;
        }

        public IList<Employee> GetEmployees()
        {
            return _db.Select<Employee>();
        }
    }
}
