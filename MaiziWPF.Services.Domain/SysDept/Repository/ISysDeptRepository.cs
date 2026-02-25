using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysDeptRepository : IBaseRepository<SysDept, int>, ITransientDependency
    {
        /**
         * 查询部门管理数据
         * 
         * @param dept 部门信息
         * @return 部门信息集合
         */
        public List<SysDept> SelectDeptList(SysDept dept, bool isTreeQuery);
    }
}
