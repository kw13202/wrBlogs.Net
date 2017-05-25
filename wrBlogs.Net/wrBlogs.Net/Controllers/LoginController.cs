using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wrBlogs.Net.ViewModel;
using wrBlogs.Net.Context;

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
        /// ��¼����
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginIn()
        {
            return View();
        }

        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //����û���Ϣ
                var user = await _userRepository.CheckUser(model.UserName, model.Password);
                if(user != null)
                {
                    //��ת��ϵͳ��ҳ
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "�û������������";
                return View(model);
            }
            //ȡ��һ��������Ϣ
            ViewBag.ErrorInfo = ModelState.Values.First().Errors[0].ErrorMessage;
            return View(model);
        }
    }
}