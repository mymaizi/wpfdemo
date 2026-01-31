using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 岗位信息表 sys_post
    /// 注意：与原表有差异
    /// </summary>
    [Table(Name = "SysRole")]
    public class SysPost: BaseEntity
    {
        /** 岗位序号 */
        [Column(Name = "post_id", IsIdentity = true, IsPrimary = true)]
        public Int64 PostId { get; set; }
        /** 用户ID */
        [Column(Name = "post_code")]
        public String PostCode { get; set; }
        /** 用户ID */
        [Column(Name = "post_name")]
        public String PostName { get; set; }
        /** 用户ID */
        [Column(Name = "post_sort")]
        public Int32 PostSort { get; set; }
        /** 状态（0正常 1停用） */
        [Column(Name = "status")]
        public String Status { get; set; }
        /** 备注 */
        [Column(Name = "remark")]
        public String Remark { get; set; }
    }
}
