

using Blog.Common;
using Blog.Model;
using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            this._articleService = articleService;
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Add(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var aritcle = _articleService.Detail(id);

                return View(aritcle);
            }

            return View();
        }

        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromBody] Article article)
        {
            article.Author = "lsp";

            _articleService.Add(article);
            return Content("ok:添加成功！");

            //var f = ModelState.IsValid;

            //return Content("ok:添加成功！");
        }

        /// <summary>
        /// 博客列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleList()
        {
            return View();
        }

        /// <summary>
        /// 博客列表
        /// </summary>
        /// <returns></returns>
        public IActionResult GetArticleList(string title, string content)
        {
            PageData pageData = new PageData();
            pageData.count = _articleService.GetArticleCount("");
            pageData.data = _articleService.GetArticleList("", 1, 10);

            //string json = SerializeHelper.SerializeToString(pageData);
            //return Content(json);

            return Json(pageData);

            //return Content("OK");

            //// 前台参数
            //int pageSize = Convert.ToInt32(Request["limit"]);
            //int pageIndex = Convert.ToInt32(Request["page"]);
            //string name = Request["name"]?.ToString();
            //int rowCount = 0;

            //var userinfo = sysUserInfoService.QueryByPage(pageIndex, pageSize, out rowCount, c => c.uLoginName.Contains(name), c => c.uID, false);

            //PageData pageData = new PageData();
            //pageData.code = 0;
            //pageData.msg = "";
            //pageData.count = rowCount;
            //pageData.data = userinfo;

            //string json = SerializeHelper.SerializeToString(pageData);
            //return Content(json);


            string str = "{\"code\":0,\"msg\":\"\",\"count\":1000,\"data\":[{\"id\":10000,\"username\":\"user-0\",\"sex\":\"女\",\"city\":\"城市-0\",\"sign\":\"签名-0\",\"experience\":255,\"logins\":24,\"wealth\":82830700,\"classify\":\"作家\",\"score\":57},{\"id\":10001,\"username\":\"user-1\",\"sex\":\"男\",\"city\":\"城市-1\",\"sign\":\"签名-1\",\"experience\":884,\"logins\":58,\"wealth\":64928690,\"classify\":\"词人\",\"score\":27},{\"id\":10002,\"username\":\"user-2\",\"sex\":\"女\",\"city\":\"城市-2\",\"sign\":\"签名-2\",\"experience\":650,\"logins\":77,\"wealth\":6298078,\"classify\":\"酱油\",\"score\":31},{\"id\":10003,\"username\":\"user-3\",\"sex\":\"女\",\"city\":\"城市-3\",\"sign\":\"签名-3\",\"experience\":362,\"logins\":157,\"wealth\":37117017,\"classify\":\"诗人\",\"score\":68},{\"id\":10004,\"username\":\"user-4\",\"sex\":\"男\",\"city\":\"城市-4\",\"sign\":\"签名-4\",\"experience\":807,\"logins\":51,\"wealth\":76263262,\"classify\":\"作家\",\"score\":6},{\"id\":10005,\"username\":\"user-5\",\"sex\":\"女\",\"city\":\"城市-5\",\"sign\":\"签名-5\",\"experience\":173,\"logins\":68,\"wealth\":60344147,\"classify\":\"作家\",\"score\":87},{\"id\":10006,\"username\":\"user-6\",\"sex\":\"女\",\"city\":\"城市-6\",\"sign\":\"签名-6\",\"experience\":982,\"logins\":37,\"wealth\":57768166,\"classify\":\"作家\",\"score\":34},{\"id\":10007,\"username\":\"user-7\",\"sex\":\"男\",\"city\":\"城市-7\",\"sign\":\"签名-7\",\"experience\":727,\"logins\":150,\"wealth\":82030578,\"classify\":\"作家\",\"score\":28},{\"id\":10008,\"username\":\"user-8\",\"sex\":\"男\",\"city\":\"城市-8\",\"sign\":\"签名-8\",\"experience\":951,\"logins\":133,\"wealth\":16503371,\"classify\":\"词人\",\"score\":14},{\"id\":10009,\"username\":\"user-9\",\"sex\":\"女\",\"city\":\"城市-9\",\"sign\":\"签名-9\",\"experience\":484,\"logins\":25,\"wealth\":86801934,\"classify\":\"词人\",\"score\":75},{\"id\":10010,\"username\":\"user-10\",\"sex\":\"女\",\"city\":\"城市-10\",\"sign\":\"签名-10\",\"experience\":1016,\"logins\":182,\"wealth\":71294671,\"classify\":\"诗人\",\"score\":34},{\"id\":10011,\"username\":\"user-11\",\"sex\":\"女\",\"city\":\"城市-11\",\"sign\":\"签名-11\",\"experience\":492,\"logins\":107,\"wealth\":8062783,\"classify\":\"诗人\",\"score\":6},{\"id\":10012,\"username\":\"user-12\",\"sex\":\"女\",\"city\":\"城市-12\",\"sign\":\"签名-12\",\"experience\":106,\"logins\":176,\"wealth\":42622704,\"classify\":\"词人\",\"score\":54},{\"id\":10013,\"username\":\"user-13\",\"sex\":\"男\",\"city\":\"城市-13\",\"sign\":\"签名-13\",\"experience\":1047,\"logins\":94,\"wealth\":59508583,\"classify\":\"诗人\",\"score\":63},{\"id\":10014,\"username\":\"user-14\",\"sex\":\"男\",\"city\":\"城市-14\",\"sign\":\"签名-14\",\"experience\":873,\"logins\":116,\"wealth\":72549912,\"classify\":\"词人\",\"score\":8},{\"id\":10015,\"username\":\"user-15\",\"sex\":\"女\",\"city\":\"城市-15\",\"sign\":\"签名-15\",\"experience\":1068,\"logins\":27,\"wealth\":52737025,\"classify\":\"作家\",\"score\":28},{\"id\":10016,\"username\":\"user-16\",\"sex\":\"女\",\"city\":\"城市-16\",\"sign\":\"签名-16\",\"experience\":862,\"logins\":168,\"wealth\":37069775,\"classify\":\"酱油\",\"score\":86},{\"id\":10017,\"username\":\"user-17\",\"sex\":\"女\",\"city\":\"城市-17\",\"sign\":\"签名-17\",\"experience\":1060,\"logins\":187,\"wealth\":66099525,\"classify\":\"作家\",\"score\":69},{\"id\":10018,\"username\":\"user-18\",\"sex\":\"女\",\"city\":\"城市-18\",\"sign\":\"签名-18\",\"experience\":866,\"logins\":88,\"wealth\":81722326,\"classify\":\"词人\",\"score\":74},{\"id\":10019,\"username\":\"user-19\",\"sex\":\"女\",\"city\":\"城市-19\",\"sign\":\"签名-19\",\"experience\":682,\"logins\":106,\"wealth\":68647362,\"classify\":\"词人\",\"score\":51},{\"id\":10020,\"username\":\"user-20\",\"sex\":\"男\",\"city\":\"城市-20\",\"sign\":\"签名-20\",\"experience\":770,\"logins\":24,\"wealth\":92420248,\"classify\":\"诗人\",\"score\":87},{\"id\":10021,\"username\":\"user-21\",\"sex\":\"男\",\"city\":\"城市-21\",\"sign\":\"签名-21\",\"experience\":184,\"logins\":131,\"wealth\":71566045,\"classify\":\"词人\",\"score\":99},{\"id\":10022,\"username\":\"user-22\",\"sex\":\"男\",\"city\":\"城市-22\",\"sign\":\"签名-22\",\"experience\":739,\"logins\":152,\"wealth\":60907929,\"classify\":\"作家\",\"score\":18},{\"id\":10023,\"username\":\"user-23\",\"sex\":\"女\",\"city\":\"城市-23\",\"sign\":\"签名-23\",\"experience\":127,\"logins\":82,\"wealth\":14765943,\"classify\":\"作家\",\"score\":30},{\"id\":10024,\"username\":\"user-24\",\"sex\":\"女\",\"city\":\"城市-24\",\"sign\":\"签名-24\",\"experience\":212,\"logins\":133,\"wealth\":59011052,\"classify\":\"词人\",\"score\":76},{\"id\":10025,\"username\":\"user-25\",\"sex\":\"女\",\"city\":\"城市-25\",\"sign\":\"签名-25\",\"experience\":938,\"logins\":182,\"wealth\":91183097,\"classify\":\"作家\",\"score\":69},{\"id\":10026,\"username\":\"user-26\",\"sex\":\"男\",\"city\":\"城市-26\",\"sign\":\"签名-26\",\"experience\":978,\"logins\":7,\"wealth\":48008413,\"classify\":\"作家\",\"score\":65},{\"id\":10027,\"username\":\"user-27\",\"sex\":\"女\",\"city\":\"城市-27\",\"sign\":\"签名-27\",\"experience\":371,\"logins\":44,\"wealth\":64419691,\"classify\":\"诗人\",\"score\":60},{\"id\":10028,\"username\":\"user-28\",\"sex\":\"女\",\"city\":\"城市-28\",\"sign\":\"签名-28\",\"experience\":977,\"logins\":21,\"wealth\":75935022,\"classify\":\"作家\",\"score\":37},{\"id\":10029,\"username\":\"user-29\",\"sex\":\"男\",\"city\":\"城市-29\",\"sign\":\"签名-29\",\"experience\":647,\"logins\":107,\"wealth\":97450636,\"classify\":\"酱油\",\"score\":27}]}";

            return Content(str);
        }

        /// <summary>
        /// 博客详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// 图片上传
        /// 注入 IHostingEnvironment
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Upload([FromServices] IHostingEnvironment hostingEnvironment)
        {
            var file = Request.Form.Files[0];
            string webRootPath = hostingEnvironment.WebRootPath;// "\\wwwroot";
            string contentRootPath = hostingEnvironment.ContentRootPath;//  "\\wwwroot";
            var fileUrl = string.Empty;
            var filePath = string.Empty;

            if (file?.Length > 0)
            {
                // 文件名
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString() + ".jpg";
                // 存放路径
                fileUrl = @"/upload/images";

                if (!Directory.Exists(webRootPath + fileUrl))
                {
                    Directory.CreateDirectory(webRootPath + fileUrl);
                }

                filePath = Path.Combine(fileUrl, fileName);

                using (var stream = new FileStream(webRootPath + filePath, FileMode.CreateNew))
                {
                    await file.CopyToAsync(stream);
                }
            }

            JObject jObject = new JObject();
            jObject.Add("errno", 0);
            jObject.Add("data", new JArray("https://localhost:44381" + filePath));

            return Json(jObject);


            #region .netframework 写法
            //// 文件保存目录路径
            //string savePath = "/upload/";

            //// 定义允许上传的文件扩展名
            //Hashtable extTable = new Hashtable();
            //extTable.Add("image", "gif,jpb,jpeg,png,bmp");
            //extTable.Add("flash", "swf,flv");
            //extTable.Add("media", "swf,flv,mp3,wav,wmv,mid,avi,mpg,asf,rm,rmvb");
            //extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            //// 最大文件大小
            //int maxSize = 1000 * 1000;

            //HttpPostedFileBase imgFile = Request.Files["imgFile"];

            //if (imgFile == null)
            //{
            //    return Content("error|请选择文件");
            //}

            //string dirPath = Server.MapPath(savePath);
            //if (!Directory.Exists(dirPath))
            //{
            //    Directory.CreateDirectory(savePath);
            //}

            //string dirName = Request.QueryString["dir"];
            //if (string.IsNullOrWhiteSpace(dirName))
            //{
            //    dirName = "image";
            //}

            //if (!extTable.ContainsKey(dirName))
            //{
            //    return Content("error|目录名不正确");
            //}

            //string fileName = imgFile.FileName;
            //string fileExt = Path.GetExtension(fileName).ToLower();

            //if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            //{
            //    return Content("error|上传文件大小超过限制");
            //}

            //if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(((string)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            //{
            //    return Content("error|上传文件扩展名是不允许的扩展名,\n只允许" + ((string)extTable[fileName]) + "格式");
            //}

            //// 创建文件夹
            //dirPath += dirName + "/";
            //if (!Directory.Exists(dirPath))
            //{
            //    Directory.CreateDirectory(dirPath);
            //}

            //string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            //dirPath += ymd + "/";
            //if (!Directory.Exists(dirPath))
            //{
            //    Directory.CreateDirectory(dirPath);
            //}

            //string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            //string filePath = dirPath + newFileName;
            //imgFile.SaveAs(filePath);

            //string fileUrl = savePath + "image/" + ymd + "/" + newFileName;
            //JObject jObject = new JObject();
            //jObject.Add("errno", 0);
            //jObject.Add("data", new JArray(fileUrl));
            //return Json(JsonConvert.SerializeObject(jObject));
            #endregion
        }

        /// <summary>
        /// 博客分类页面
        /// </summary>
        /// <returns></returns>
        public IActionResult CategoryList()
        {
            return View();
        }

        /// <summary>
        /// 获取博客分类列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult GetCategoryList(string name, int limit, int page)
        {
            PageData pageData = new PageData();
            pageData.count = _articleService.GetCategoryCount("");
            pageData.data = _articleService.GetCategoryList(name, page, limit);

            //string json = SerializeHelper.SerializeToString(pageData);
            //return Content(json);

            return Json(pageData);
        }


        /// <summary>
        /// 博客分类添加编辑页面
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IActionResult CategoryAdd(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var category = _articleService.GetCategory(" Value = " + value);

                return View(category);
            }

            return View();
        }

        /// <summary>
        /// 添加博客分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryAdd(Category category)
        {
            if (!string.IsNullOrWhiteSpace(category.Id))
            {
                await _articleService.CategoryEdit(category);
            }
            else
            {
                //await _articleService.CategoryAdd(category);
            }
            
            return Content("添加编辑文章分类成功");
        }

        /// <summary>
        /// 公告列表页面
        /// </summary>
        /// <returns></returns>
        public IActionResult TipsList()
        {
            return View();
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult GetTipsList(string name, int limit, int page)
        {
            PageData pageData = new PageData();
            pageData.count = _articleService.GetTipsCount("");
            pageData.data = _articleService.GetTipsList(name, page, limit);

            return Json(pageData);
        }

        /// <summary>
        /// 添加编辑公告页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult TipsAdd(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var tips = _articleService.GetTips(id);

                return View(tips);
            }

            return View();
        }

        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="tips"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TipsAdd(Tips tips)
        {
            if (string.IsNullOrWhiteSpace(tips.Id))
            {
                tips.Id = Guid.NewGuid().ToString("N");
                _articleService.TipsAdd(tips);
            }
            else
            {

            }

            return Content("编辑或添加公告成功");
        }

        /// <summary>
        /// 关于作者页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AboutAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutAuthor(About aboutAuthor)
        {
            if (string.IsNullOrWhiteSpace(aboutAuthor.Id))
            {
                aboutAuthor.Id = Guid.NewGuid().ToString("N");
                //_articleService
            }
            else
            {

            }

            return Content("编辑或添加公告成功");
        }


        public IActionResult Test()
        {
            return View();
        }

    }
}