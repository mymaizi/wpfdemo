using FreeSql;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysMenuRepository: IBaseRepository<SysMenu,int>, ITransientDependency
    {
        /**
        * 查询所有菜单
        *
        * @return 菜单列表
        */
        public List<SysMenu> SelectMenuTreeAll();
    }
}
