using FreeSql;
using MaiziWPF.Services.Domain.Shared;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysRoleRepository: IBaseRepository<SysRole,int>, ITransientDependency
    {
        /**
         * 根据条件分页查询角色列表
         * 
         * @param sysRole 角色信息
         * @return 角色信息集合信息
         */
        public List<SysRole> SelectRoleList(QueryRoleInput input);
    }
}
