using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using wrBlogs.Net.Model;

namespace wrBlogs.Net.Context
{
    /// <summary>
    /// 获取分页列表
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public interface ICategoryRepository
    {
        Task<PagedList> GetPage(int pageIndex, int pageSize);
    }
}
