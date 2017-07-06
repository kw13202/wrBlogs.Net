using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wrBlogs.Net.ViewModel;
using wrBlogs.Net.Context;
using wrBlogs.Net.Utils;

namespace wrBlogs.Net.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 登录界面
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginIn()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //检查用户信息
                var user = await _userRepository.CheckUser(model.UserName, model.Password);
                if(user != null)
                {
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "用户名或密码错误";
                return View(model);
            }
            //取第一条错误信息
            ViewBag.ErrorInfo = ModelState.Values.First().Errors[0].ErrorMessage;
            return View(model);
        }

        [HttpGet]
        public IActionResult ValidateCode()
        {
            string code = "";
            CodeHelper helper = new CodeHelper();
            MemoryStream ms = helper.Create(out code);
            HttpContext.Session.SetString("LoginValidateCode", code);
            return File(ms.ToArray(), @"image/png");
        }
    }
}