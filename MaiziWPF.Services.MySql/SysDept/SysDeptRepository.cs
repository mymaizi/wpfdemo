using FreeSql;
using MaiziWPF.Services.Domain;

namespace MaiziWPF.Services.MySql
{
    public class SysDeptRepository : BaseRepository<SysDept, int>, ISysDeptRepository
    {
        private readonly IFreeSql _fsql;

        public SysDeptRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysDept> SelectDeptList(SysDept dept)
        {
            System.Linq.Expressions.Expression<Func<SysDept, bool>> where = d => d.DelFlag == "0";
            if (dept.Id != 0)
                where = where.And(d => d.Id == dept.Id);
            if (dept.ParentId != 0)
                where = where.And(d => d.ParentId == dept.ParentId);
            if (!string.IsNullOrEmpty(dept.DeptName))
                where = where.And(d => d.DeptName == dept.DeptName);
            if (!string.IsNullOrEmpty(dept.Status))
                where = where.And(d => d.Status == dept.Status);
            return _fsql.Select<SysDept>().Where(where).OrderBy(a => new { a.ParentId, a.OrderNum }).ToTreeList();
        }
    }
}
