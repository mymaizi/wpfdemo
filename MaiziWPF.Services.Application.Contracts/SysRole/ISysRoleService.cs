using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts
{
    public interface ISysRoleService: ITransientDependency
    {
      
        /**
        * 根据条件分页查询角色列表
        * 
        * @param role 用户信息
        * @return 角色信息集合信息
        */
        public List<SysRole> SelectRoleList(QueryRoleInput input);
    }
}
