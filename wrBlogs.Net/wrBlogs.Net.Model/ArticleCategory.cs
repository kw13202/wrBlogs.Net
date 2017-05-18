using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.Model
{
    public class ArticleCategory
    {
        /// <summary>
        /// 博文Id
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 博文
        /// </summary>
        public virtual Article Article { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
