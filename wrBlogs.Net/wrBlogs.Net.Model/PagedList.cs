using System;
using System.Collections.Generic;
using System.Text;

namespace wrBlogs.Net.Model
{
    public class PagedList<T>
    {
        public PagedList() { }
        public PagedList(List<T> list,int pageIndex,int pageSize,int total)
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
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrePage { get { return PageIndex > 1; } }
        public bool HasNextPage { get { return PageIndex + 1 <= TotalPages; } }
        public List<T> Data { get; set; }
    }
}
