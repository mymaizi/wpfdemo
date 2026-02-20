using FreeSql;
using MaiziWPF.Services.Domain;

namespace MaiziWPF.Services.MySql
{
    public class SysMenuRepository: BaseRepository<SysMenu, int>, ISysMenuRepository
    {
        private readonly IFreeSql _fsql;

        public SysMenuRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysMenu> SelectMenuList(SysMenu menu)
        {
            System.Linq.Expressions.Expression<Func<SysMenu, bool>> where = w => w.DelFlag == "0";
            if (!string.IsNullOrEmpty(menu.MenuName))
                where = where.And(w => w.MenuName.Contains(menu.MenuName));
            if (!string.IsNullOrEmpty(menu.Status))
                where = where.And(w => w.Status == menu.Status);
            if (!string.IsNullOrEmpty(menu.MenuType))
                where = where.And(w => menu.MenuType.Split(',').Contains(w.MenuType));

            return _fsql.Select<SysMenu>().Where(where).OrderBy(o => o.OrderNum).ToTreeList();
        }

        public List<SysMenu> SelectMenuListByUserId(SysMenu menu, Int64 userId)
        {
            System.Linq.Expressions.Expression<Func<SysMenu, bool>> where = w => w.DelFlag == "0";
            if (!string.IsNullOrEmpty(menu.MenuName))
                where = where.And(w => w.MenuName.Contains(menu.MenuName));
            if (!string.IsNullOrEmpty(menu.Status))
                where = where.And(w => w.Status == menu.Status);

            return _fsql.Select<SysMenu, SysRoleMenu, SysUserRole, SysUserMenu>()
                     .LeftJoin((m, rm, ur, um) => m.Id == rm.MenuId)
                     .LeftJoin((m, rm, ur, um) => rm.RoleId == ur.RoleId)
                     .LeftJoin((m, rm, ur, um) => m.Id == um.MenuId)
                     .Where((m, rm, ur, um) => ur.UserId == userId || um.UserId == userId)
                     .WithTempQuery((m, rm, ur, um) => m)
                     .Where(where)
                     .OrderBy(o=>o.OrderNum)
                     .ToTreeList();
        }
    }
}
