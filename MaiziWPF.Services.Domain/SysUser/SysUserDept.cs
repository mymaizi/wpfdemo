using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和部门关联 sys_user_dept
    /// </summary>
    [Table(Name = "sys_user_dept")]
    public class SysUserDept
    {
        /** 用户ID */
        [Column(Name = "user_id", IsPrimary = true)]
        public Int64 UserId { get; set; }

        /** 部门ID */
        [Column(Name = "dept_id", IsPrimary = true)]
        public Int64 DeptId { get; set; }

        [Navigate(nameof(UserId))]
        public SysUser User { get; set; }

        [Navigate(nameof(DeptId))]
        public SysDept Dept { get; set; }
    }
}
