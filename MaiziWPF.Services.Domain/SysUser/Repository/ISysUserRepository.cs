using FreeSql;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysUserRepository: IBaseRepository<SysUser,int>, ITransientDependency
    {
        /**
         * 通过用户名查询用户
         * 
         * @param userName 用户名
         * @return 用户对象信息
         */
        public SysUser SelectUserByUserName(String userName);
    }
}
