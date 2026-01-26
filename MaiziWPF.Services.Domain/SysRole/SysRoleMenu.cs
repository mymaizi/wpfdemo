using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 角色和菜单关联 sys_role_menu
    /// </summary>
    public class SysRoleMenu
    {
        /** 角色ID */
        public Int64 RoleId { get; set; }

        /** 菜单ID */
        public Int64 MenuId { get; set; }
    }
}
