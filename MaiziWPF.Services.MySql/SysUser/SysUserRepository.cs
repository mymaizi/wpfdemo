using FreeSql;
using MaiziWPF.Services.Domain;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace MaiziWPF.Services.MySql
{

    public class SysUserRepository : BaseRepository<SysUser, int>, ISysUserRepository
    {
        private readonly IFreeSql _fsql;

        public SysUserRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public SysUser SelectUserByUserName(string userName)
        {
            try
            {
                return _fsql.Select<SysUser>()
                    .IncludeMany(a => a.Roles)
                    .IncludeMany(a=>a.Depts)
                    .IncludeMany(a=>a.Posts)
                    .Where(a=>a.UserName == userName)
                    .First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
