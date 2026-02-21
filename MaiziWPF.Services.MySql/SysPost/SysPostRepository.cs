using FreeSql;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.MySql
{
    public class SysPostRepository : BaseRepository<SysPost, int>, ISysPostRepository
    {
        private readonly IFreeSql _fsql;

        public SysPostRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public List<SysPost> SelectPostList(QueryPostInput input)
        {
            System.Linq.Expressions.Expression<Func<SysPost, bool>> where = d => d.DelFlag == "0";

            if (!string.IsNullOrEmpty(input.PostCode))
                where = where.And(u => u.PostCode.Contains(input.PostCode));
            if (!string.IsNullOrEmpty(input.PostName))
                where = where.And(u => u.PostName.Contains(input.PostName));
            if (!string.IsNullOrEmpty(input.Status))
                where = where.And(u => u.Status== input.Status);

            return _fsql.Select<SysPost>()
                       .Where(where)
                       .Page(input)
                       .ToList();
        }
    }
}
