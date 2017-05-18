using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.ViewModel
{
    public class JsonModel
    {
        public JsonModel(int code = 0,string msg = "",object data = null)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}
