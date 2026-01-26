using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和岗位关联 sys_user_post
    /// </summary>
    public class SysUserPost
    {
        /** 用户ID */
        public Int64 UserId { get; set; }

        /** 岗位ID */
        public Int64 PostId { get; set; }
    }
}
