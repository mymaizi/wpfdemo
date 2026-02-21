using FreeSql;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.MySql
{
    internal class SysConfigRepository : BaseRepository<SysConfig, int>, ISysConfigRepository
    {
        private readonly IFreeSql _fsql;

        public SysConfigRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysConfig> SelectConfigList(QueryConfigInput input)
        {
            System.Linq.Expressions.Expression<Func<SysConfig, bool>> where = d => d.DelFlag == "0";
            if (!string.IsNullOrEmpty(input.ConfigName))
                where = where.And(d => d.ConfigName == input.ConfigName);
            if (!string.IsNullOrEmpty(input.ConfigKey))
                where = where.And(d => d.ConfigKey == input.ConfigKey);
            if (!string.IsNullOrEmpty(input.ConfigType))
                where = where.And(d => d.ConfigType == input.ConfigType);
            if (input.StartDate.HasValue && input.EndDate.HasValue)
                where = where.And(u => u.CreateTime.Between(input.StartDate.Value, input.EndDate.Value));

            return _fsql.Select<SysConfig>().Where(where).Page(input).ToList();
        }
    }
}
