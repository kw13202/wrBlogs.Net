using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.Model
{
    public class User : EntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginCode { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

    }
}
