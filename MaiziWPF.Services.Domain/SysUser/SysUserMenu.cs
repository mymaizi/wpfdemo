using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和菜单关联 sys_user_menu
    /// </summary>
    public class SysUserMenu
    {
        /** 用户ID */
        public Int64 UserId { get; set; }

        /** 菜单ID */
        public Int64 MenuId { get; set; }
    }
}
