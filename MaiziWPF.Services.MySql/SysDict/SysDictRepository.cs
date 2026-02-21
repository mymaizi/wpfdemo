using FreeSql;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;

namespace MaiziWPF.Services.MySql
{
    public class SysDictRepository : BaseRepository<SysDictType, int>, ISysDictRepository
    {
        private readonly IFreeSql _fsql;

        public SysDictRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysDictData> SelectDictDataByType(string dictType)
        {
            return _fsql.Select<SysDictData>().Where(w=>w.Status=="0" && w.DictType==dictType).OrderBy(o=>o.DictSort).ToList();
        }

        public List<SysDictType> SelectDictTypeList(QueryDictTypeInput input)
        {
            System.Linq.Expressions.Expression<Func<SysDictType, bool>> where = w => w.DelFlag == "0";
            if (!string.IsNullOrEmpty(input.DictName))
                where = where.And(w => w.DictName.Contains(input.DictName));
            if (!string.IsNullOrEmpty(input.Status))
                where = where.And(w => w.Status == input.Status);
            if (!string.IsNullOrEmpty(input.DictType))
                where = where.And(w => w.DictType.Contains(input.DictType));
            if (input.StartDate.HasValue && input.EndDate.HasValue)
                where = where.And(u => u.CreateTime.Between(input.StartDate.Value, input.EndDate.Value));

            return _fsql.Select<SysDictType>().Where(where).Page(input).ToList();
        }
    }
}
