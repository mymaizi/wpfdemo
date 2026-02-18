using FreeSql;
using MaiziWPF.Services.Domain.Shared;
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
        /**
         * 根据条件分页查询用户列表
         * 
         * @param sysUser 用户信息
         * @return 用户信息集合信息
         */
        public List<SysUser> SelectUserList(QueryUserInput input);
    }
}
