using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和角色关联 sys_user_role
    /// </summary>
    [Table(Name = "sys_user_role")]
    public class SysUserRole
    {
        /** 用户ID */
        [Column(Name = "user_id", IsPrimary = true)]
        public Int64 UserId { get; set; }

        /** 角色ID */
        [Column(Name = "role_id", IsPrimary = true)]
        public Int64 RoleId { get; set; }

        [Navigate(nameof(UserId))]
        public SysUser User { get; set; }

        [Navigate(nameof(RoleId))]
        public SysRole Role { get; set; }
    }
}
