using MaiziWPF.Common;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;

namespace MaiziWPF.Services.Application
{
    public class SysMenuService : ISysMenuService
    {
        private readonly ISysMenuRepository _repository;

        public SysMenuService(ISysMenuRepository repository)

        {
            _repository = repository;
        }

        public List<SysMenu> SelectMenuList(SysMenu menu, Int64 userId)
        {
            List<SysMenu> menuList = null;
            // 管理员显示所有菜单信息
            if (SecurityUtils.IsAdmin(userId))
            {
                menuList = _repository.SelectMenuList(menu);
            }
            else
            {
                menuList = _repository.SelectMenuListByUserId(menu, userId);
            }
            return menuList;
        }

        public List<SysMenu> SelectMenuTreeAll()
        {
            return _repository.SelectMenuTreeAll();
        }
    }
}
