using System;
using System.Collections.Generic;
using System.Text;
using wrBlogs.Net.Model;

namespace wrBlogs.Net.Context
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

    }
}
