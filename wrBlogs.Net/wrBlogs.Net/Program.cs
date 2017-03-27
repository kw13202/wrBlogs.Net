using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace wrBlogs.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                //读取hosting.json配置
                .AddJsonFile("hosting.json", optional: true)
                //.AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                //程序写死设置启动端口，不方便配置
                //.UseUrls("http://*:5001")
                //使用Kestrel服务器
                .UseKestrel()
                //内容的根目录
                .UseContentRoot(Directory.GetCurrentDirectory())
                //IIS集成
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                //加载配置
                .UseConfiguration(config)
                .Build();

            host.Run();
        }
    }
}
