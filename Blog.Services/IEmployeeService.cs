using Blog.Common;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services
{
    public interface IEmployeeService : IService
    {
        IList<Employee> GetEmployees();
    }
}
