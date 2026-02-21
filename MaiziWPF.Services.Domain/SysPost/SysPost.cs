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
    [Table(Name = "sys_post")]
    public class SysPost: BaseEntity
    {
        /** 岗位序号 */
        [Column(Name = "post_id", IsIdentity = true, IsPrimary = true)]
        public Int64 PostId { get; set; }
        /** 用户ID */
        [Column(Name = "post_code",DbType = "varchar(64)")]
        public String PostCode { get; set; }
        /** 用户ID */
        [Column(Name = "post_name", DbType = "varchar(50)")]
        public String PostName { get; set; }
        /** 用户ID */
        [Column(Name = "post_sort")]
        public Int32 PostSort { get; set; }
        /** 状态（0正常 1停用） */
        [Column(Name = "status", DbType = "char(1)")]
        public String Status { get; set; }
        /** 备注 */
        [Column(Name = "remark", DbType = "varchar(500)")]
        public String Remark { get; set; }
    }
}
