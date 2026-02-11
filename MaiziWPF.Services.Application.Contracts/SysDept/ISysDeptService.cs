using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts
{
    public interface ISysDeptService: ITransientDependency
    {
        /**
        * 查询部门树结构信息
        * 
        * @param dept 部门信息
        * @return 部门树信息集合
        */
        public List<SysDept> SelectDeptTreeList(SysDept dept);
    }
}
