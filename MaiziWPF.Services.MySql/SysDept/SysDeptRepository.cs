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
            var where = PredicateBuilder.New<SysDept>();
            where = where.And(w => w.DelFlag == "0");
            if (dept.Id != 0)
                where = where.And(w => w.Id == dept.Id);
            if (dept.ParentId != 0)
                where = where.And(w => w.ParentId == dept.ParentId);
            if (!string.IsNullOrEmpty(dept.DeptName))
                where = where.And(w => w.DeptName == dept.DeptName);
            if (!string.IsNullOrEmpty(dept.Status))
                where = where.And(w => w.Status == dept.Status);
            return _fsql.Select<SysDept>().Where(where).OrderBy(a => new { a.ParentId, a.OrderNum }).ToTreeList();
        }
    }
}
