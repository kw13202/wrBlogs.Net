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
                //添加分类
                var categoryList = new List<Model.Category>
                {
                    new Model.Category{ CategoryName = "C#", IsVisible = true },
                    new Model.Category{ CategoryName = "SQL", IsVisible = true },
                    new Model.Category{ CategoryName = "Java", IsVisible = true },
                    new Model.Category{ CategoryName = "JavaScript", IsVisible = true },
                    new Model.Category{ CategoryName = "NodeJS", IsVisible = true },
                    new Model.Category{ CategoryName = "VueJS", IsVisible = true },
                    new Model.Category{ CategoryName = "CSS", IsVisible = true },
                    new Model.Category{ CategoryName = "HTML", IsVisible = true },
                    new Model.Category{ CategoryName = "Python", IsVisible = true },
                    new Model.Category{ CategoryName = "C++", IsVisible = true },
                };
                context.Category.AddRange(categoryList);

                context.SaveChanges();
            }
        }
    }
}
