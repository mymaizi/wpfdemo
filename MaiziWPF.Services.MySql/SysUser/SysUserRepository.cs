using FreeSql;
using MaiziWPF.Services.Domain;

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
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
