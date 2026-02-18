using FreeSql;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;

namespace MaiziWPF.Services.MySql
{

    public class SysRoleRepository : BaseRepository<SysRole, int>, ISysRoleRepository
    {
        private readonly IFreeSql _fsql;

        public SysRoleRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysRole> SelectRoleList(QueryRoleInput input)
        {
            System.Linq.Expressions.Expression<Func<SysRole, bool>> where = d => d.DelFlag == "0";

            if (!string.IsNullOrEmpty(input.RoleName))
                where = where.And(u => u.RoleName.Contains(input.RoleName));
            if (!string.IsNullOrEmpty(input.RoleKey))
                where = where.And(u => u.RoleKey.Contains(input.RoleKey));
            if (!string.IsNullOrEmpty(input.Status))
                where = where.And(u => u.Status.Contains(input.Status));
            if (input.StartDate.HasValue && input.EndDate.HasValue)
                where = where.And(u => u.CreateTime.Between(input.StartDate.Value, input.EndDate.Value));

            return _fsql.Select<SysRole>()
                       .Where(where)
                       .Page(input)
                       .ToList();
        }
    }
}
