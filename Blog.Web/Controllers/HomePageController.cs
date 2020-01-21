using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Web.Models;
using Blog.Services;
using Blog.Model;
using Blog.Common;

namespace Blog.Web.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IArticleService _articleService;

        public HomePageController(IEmployeeService employeeService, IArticleService articleService)
        {
            _employeeService = employeeService;
            _articleService = articleService;
        }

        /// <summary>
        /// 前台-网站首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //List<Tips> tipsList = new List<Tips> {
            //    new Tips(){ Color = "#009688", Text = "偷偷告诉大家，本博客的后台管理也正在制作，为大家准备了游客专用账号！"},
            //    new Tips(){ Color = "red",Text="网站新增留言回复啦！使用QQ登陆即可回复，人人都可以回复！"},
            //    new Tips(){ Color="red",Text="如果你觉得网站做得还不错，来Fly社区点个赞吧！", Url = "http://fly.layui.com/case/2017/", UrlTips = "点我前往"},
            //    new Tips(){ Color="#009688",Text="不落阁 —— ;一个.NET程序员的个人博客，新版网站采用Layui为前端框架，目前正在建设中！"}
            //};

            var tipsList = _articleService.GetTipsList("", 0, 999999);

            // 公告列表
            ViewBag.TipsList = tipsList;

            // 博客列表
            ViewBag.BlogList = _articleService.GetArticleList("", 1, 10);

            // 导航，当前 Action 的名称
            ViewBag.SelectNav = "Index";

            return View();
        }

        /// <summary>
        /// 前台-文章专栏
        /// </summary>
        /// <returns></returns>
        public IActionResult Article()
        {
            //List<Tips> tipsList = new List<Tips> {
            //    new Tips(){ Color = "#009688", Text = "偷偷告诉大家，本博客的后台管理也正在制作，为大家准备了游客专用账号！"},
            //    new Tips(){ Color = "red",Text="网站新增留言回复啦！使用QQ登陆即可回复，人人都可以回复！"},
            //    new Tips(){ Color="red",Text="如果你觉得网站做得还不错，来Fly社区点个赞吧！", Url = "http://fly.layui.com/case/2017/", UrlTips = "点我前往"},
            //    new Tips(){ Color="#009688",Text="不落阁 —— ;一个.NET程序员的个人博客，新版网站采用Layui为前端框架，目前正在建设中！"}
            //};

            var tipsList = _articleService.GetTipsList("", 0, 999999);

            // 公告列表
            ViewBag.TipsList = tipsList;

            // 博客列表
            ViewBag.BlogList = _articleService.GetArticleList("", 1, 10);

            // 导航，当前 Action 的名称
            ViewBag.SelectNav = "Article";

            return View();
        }

        /// <summary>
        /// 前台-资源分享
        /// </summary>
        /// <returns></returns>
        public IActionResult Resource()
        {
            // 导航，当前 Action 的名称
            ViewBag.SelectNav = "Resource";

            return View();
        }

        /// <summary>
        /// 前台-时光轴
        /// </summary>
        /// <returns></returns>
        public IActionResult TimeLine()
        {
            // 导航，当前 Action 的名称
            ViewBag.SelectNav = "TimeLine";

            return View();
        }

        /// <summary>
        /// 前台-关于本站
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            // 导航，当前 Action 的名称
            ViewBag.SelectNav = "About";

            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 前台-文章详情
        /// </summary>
        /// <returns></returns>
        [Route("Article/Detail/{ArticleID}")]
        public ActionResult Detail(string articleID)
        {
            // 导航
            ViewBag.SelectNav = "Article";

            if (string.IsNullOrWhiteSpace(articleID))
            {
                throw new Exception("文章id为空");
            }
            return View();
        }

        /// <summary>
        /// 前台-文章分类显示
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        [Route("Article/Category/{CategoryID}")]
        public ActionResult Category(string categoryID)
        {
            return View("Article");
        }

        /// <summary>
        /// 前台-文章搜索
        /// </summary>
        /// <returns></returns>
        [Route("Article/Search")]
        public ActionResult Search()
        {
            return View("Article");
        }


        public IActionResult Index2()
        {
            var list = _employeeService.GetEmployees();

            return View(list);
        }
        

        class message
        {
            public bool Success { get; set; }
            public string msg { get; set; }
            public DateTime dateTime { get; set; }
        }

        [HttpPost]
        public JsonResult GetMoreArticle([FromBody] string search, PageData pageData)
        {
            message msg = new message();
            msg.Success = true;
            msg.msg = "test";
            msg.dateTime = DateTime.Now;
            return Json(msg);
        }
    }
}
