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

        public List<SysMenu> SelectMenuTreeAll()
        {
            return _fsql.Select<SysMenu>().Where(a => new[] { "M", "C" }.Contains(a.MenuType) && a.Status=="0").OrderBy(a => new { a.ParentId, a.OrderNum }).ToTreeList();
        }
    }
}
