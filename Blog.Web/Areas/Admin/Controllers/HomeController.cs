using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        //IsysUserInfoServices userinfoservice = new sysUserInfoServices();
        IEmployeeService employeeService;
        /// <summary>
        /// 使用autofac 构造函数方式构造对象
        /// </summary>
        /// <param name="userInfo"></param>
        public HomeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public ActionResult Index()
        {
            // 日志测试
            //int i = 1;
            //int b = 0;
            //int c;
            //c = i / b;

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}