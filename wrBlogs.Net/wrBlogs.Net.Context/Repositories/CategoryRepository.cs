using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wrBlogs.Net.Model;

namespace wrBlogs.Net.Context
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PagedList> GetPage(int pageIndex,int pageSize)
        {
            int total = _dbContext.Category.Count();
            var list = await _dbContext.Category.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList(list, pageIndex, pageSize, total);
        }

    }
}
