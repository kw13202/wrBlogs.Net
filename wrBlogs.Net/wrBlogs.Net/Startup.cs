using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//通过nuget添加的包
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using wrBlogs.Net.Context;


namespace wrBlogs.Net
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            var sqlConnectionString = Configuration.GetConnectionString("Default");
            //添加数据上下文
            services.AddDbContext<BlogDbContext>(options =>
                //SqlServer
                //options.UseSqlServer(sqlConnectionString)
                //Sqlite
                options.UseSqlite(sqlConnectionString)
            );
            //依赖注入
            services.AddScoped<IUserRepository, UserRepository>();

            //添加MVC  --Microsoft.AspNetCore.Mvc
            services.AddMvc();
            //添加缓存  --Microsoft.Extensions.Caching.Memory
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            //添加Session  --Microsoft.AspNetCore.Session
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //设置路由规则
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            Configure(app);
        }

        /// <summary>
        /// 配置通用内容
        /// </summary>
        /// <param name="app"></param>

        private void Configure(IApplicationBuilder app)
        {
            //启用Session  --Microsoft.AspNetCore.Session
            app.UseSession();
            //启用静态文件  --Microsoft.AspNetCore.StaticFiles
            app.UseStaticFiles();
            //初始化数据
            SeedData.Initialize(app.ApplicationServices);
        }
    }
}
