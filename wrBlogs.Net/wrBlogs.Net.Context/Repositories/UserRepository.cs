using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wrBlogs.Net.Model;

namespace wrBlogs.Net.Context
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="loginCode">用户名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        public Task<User> CheckUser(string loginCode, string loginPwd)
        {
            return _dbContext.Set<User>().FirstOrDefaultAsync(x => x.LoginCode == loginCode && x.LoginPwd == loginPwd);
        }
    }
}
