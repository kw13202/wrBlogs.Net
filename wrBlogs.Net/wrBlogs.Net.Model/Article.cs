using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.Model
{
    public class Article : EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Titile { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 博文-分类集合
        /// </summary>
        public virtual ICollection<ArticleCategory> ArticleCategory { get; set; }
    }
}
