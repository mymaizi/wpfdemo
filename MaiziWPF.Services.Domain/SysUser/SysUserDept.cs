using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和部门关联 sys_user_dept
    /// </summary>
    public class SysUserDept
    {
        /** 用户ID */
        public Int64 UserId { get; set; }

        /** 部门ID */
        public Int64 DeptId { get; set; }
    }
}
