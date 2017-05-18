using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wrBlogs.Net.ViewModel;
using wrBlogs.Net.Context;

namespace wrBlogs.Net.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region 界面
        /// <summary>
        /// 分类列表界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            
            return View();
        } 
        #endregion

        

    }
}