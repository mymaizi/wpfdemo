using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        /**
        * 根据用户查询系统菜单列表
        * 
        * @param menu 菜单信息
        * @param userId 用户ID
        * @return 菜单列表
        */
        public List<SysMenu> SelectMenuList(SysMenu menu, Int64 userId);
    }
}
