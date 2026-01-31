using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户和岗位关联 sys_user_post
    /// </summary>
    [Table(Name = "sys_user_post")]
    public class SysUserPost
    {
        /** 用户ID */
        [Column(Name = "user_id", IsPrimary = true)]
        public Int64 UserId { get; set; }

        /** 岗位ID */
        [Column(Name = "post_id", IsPrimary = true)]
        public Int64 PostId { get; set; }

        [Navigate(nameof(UserId))]
        public SysUser User { get; set; }

        [Navigate(nameof(PostId))]
        public SysPost Post { get; set; }
    }
}
