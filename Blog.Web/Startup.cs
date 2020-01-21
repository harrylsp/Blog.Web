using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blog.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Blog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    // 不使用驼峰样式的key，默认的驼峰式的key，首字母会小写
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                    // 格式化 序列化Json时的时间格式，当你使用MVC自带的 返回数据类型 Json 才会生效
                    options.SerializerSettings.DateFormatString = "yyyy-MM-ss HH:mm:ss";
                });

            #region IOC 注册程序集

            var builder = new ContainerBuilder();

            var fileNameRegex = new Regex($@"({"Blog"})\.[^\\]*\.dll", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //预先加载dll
            Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(it => fileNameRegex.IsMatch(it))
                .Each(file => AssemblyLoadContext.Default.LoadFromAssemblyPath(file));

            //注册IOC
            var assembiles = AppDomain.CurrentDomain.GetAssemblies()
                .Where(it => !it.IsDynamic && fileNameRegex.IsMatch(Path.GetFileName(it.Location)))
                .ToArray();

            // 正常注册所有 继承 IDependency 默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
            builder.RegisterAssemblyTypes(assembiles)
                .Except<IDependencySingleton>()
                .Except<IDependencyRequestSingleton>()
                .As<IDependency>().AsSelf().AsImplementedInterfaces();

            // 注册 所有 继承 IDependencySingleton 为 单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象
            builder.RegisterAssemblyTypes(assembiles)
                .Except<IDependencyRequestSingleton>()
                .As<IDependencySingleton>()
                .AsSelf().AsImplementedInterfaces()
                .SingleInstance();

            // 注册 所有继承 IDependencyRequestSingleton 在 同一个Lifetime生成的对象是同一个实例
            builder.RegisterAssemblyTypes(assembiles)
                .As<IDependencyRequestSingleton>()
                .AsSelf().AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            #endregion

            #region 替换自带的依赖注入，使用 AutoFac
            builder.Populate(services);

            var container = builder.Build();
            this.ApplicationContainer = container;

            return new AutofacServiceProvider(this.ApplicationContainer);

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Upload")),
            //    RequestPath = new PathString("/src")
            //});

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                // 匹配所有的区域 需要在对应Controller 上添加区域属性 如：[Area("Admin")]
                // 把 Area的路由放在第一位，会保证 在 Areas 下的视图，使用 TagHelper 时候，
                // 使用 asp-area asp-controller asp-action 能正确的匹配上
                // 如果不把这个路由放在这里，当你的Areas下的视图的路径 和 非Areas 目录下的视图
                // asp-controller asp-action 一样时，会匹配第一个能合适的路由
                // 而这时，你在 Areas 下的视图，就没有匹配到正确的路径
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "HomePage",
                    template: "{action}",
                    defaults: new
                    {
                        controller = "HomePage",
                        action = "Index",
                        id = 0
                    });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=HomePage}/{action=Index}/{id?}");

            });

        }
    }
}
