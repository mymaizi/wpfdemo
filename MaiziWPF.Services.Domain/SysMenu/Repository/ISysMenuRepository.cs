using FreeSql;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysMenuRepository : IBaseRepository<SysMenu, int>, ITransientDependency
    {
        /**
        * 查询所有菜单
        *
        * @return 菜单列表
        */
        public List<SysMenu> SelectMenuTreeAll();
        /**
         * 查询系统菜单列表
         *
         * @param menu 菜单信息
         * @return 菜单列表
         */
        public List<SysMenu> SelectMenuList(SysMenu menu);

        /**
           * 根据用户查询系统菜单列表
           *
           * @param menu 菜单信息
           * @return 菜单列表
           */
        public List<SysMenu> SelectMenuListByUserId(SysMenu menu,Int64 userId);
    }
}
