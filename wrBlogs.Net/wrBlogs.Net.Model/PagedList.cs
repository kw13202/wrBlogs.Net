using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.Model
{
    public class PagedList
    {
        public PagedList(object list,int pageIndex,int pageSize,int total)
        {
            Data = list;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = total;
            TotalPages = total / pageSize;
            if (total % pageSize > 0)
                TotalPages++;
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPrePage { get { return PageIndex > 1; } }
        public bool HasNextPage { get { return PageIndex + 1 <= TotalPages; } }
        public object Data { get; private set; }
    }
}
