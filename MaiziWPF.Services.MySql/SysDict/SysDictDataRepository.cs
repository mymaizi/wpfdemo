using FreeSql;
using MaiziWPF.Services.Domain;

namespace MaiziWPF.Services.MySql
{
    public class SysDictDataRepository : BaseRepository<SysDictData, int>, ISysDictDataRepository
    {
        private readonly IFreeSql _fsql;

        public SysDictDataRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysDictData> SelectDictDataByType(string dictType)
        {
            return _fsql.Select<SysDictData>().Where(w=>w.Status=="0" && w.DictType==dictType).OrderBy(o=>o.DictSort).ToList();
        }
    }
}
