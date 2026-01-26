using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和角色关联 sys_user_role
    /// </summary>
    public class SysUserRole
    {
        /** 用户ID */
        public Int64 UserId { get; set; }

        /** 角色ID */
        public Int64 RoleId { get; set; }
    }
}
