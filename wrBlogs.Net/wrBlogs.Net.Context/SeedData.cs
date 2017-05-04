using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//通过nuget添加的包
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace wrBlogs.Net.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlogDbContext(serviceProvider.GetRequiredService<DbContextOptions<BlogDbContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (context.User.Any())
                {
                    return;   // 已经初始化过数据，直接返回
                }

                //添加超级管理员
                context.User.Add(new Model.User
                {
                    UserName = "超级管理员",
                    LoginCode = "admin",
                    LoginPwd = "admin",//暂不进行加密
                    IP = "127.0.0.1"
                });

                context.SaveChanges();
            }
        }
    }
}
