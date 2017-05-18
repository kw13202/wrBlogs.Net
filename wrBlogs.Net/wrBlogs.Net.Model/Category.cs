using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.Model
{
    public class Category : EntityBase
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// 博文-分类集合
        /// </summary>
        public virtual ICollection<ArticleCategory> ArticleCategory { get; set; }
    }
}
