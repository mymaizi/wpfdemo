using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts
{
    public interface ISysMenuService : ITransientDependency
    {
        /**
       * 查询所有菜单
       *
       * @return 菜单列表
       */
        public List<SysMenu> SelectMenuTreeAll();
    }
}
