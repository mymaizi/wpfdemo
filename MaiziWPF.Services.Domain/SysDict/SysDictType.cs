using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 字典类型表 sys_dict_type
    /// 注意：与原表有差异
    /// </summary>

    [Index("uk_dictType", "DictType", true)]
    [Table(Name = "sys_dict_type")]
    public class SysDictType: BaseEntity
    {
        /** 字典编码 */
        [Column(Name = "dict_id", IsIdentity = true, IsPrimary = true)]
        public Int64 DictId { get; set; }
        /** 字典排序 */
        [Column(Name = "dict_name",DbType = "varchar(100)")]
        public String DictName { get; set; }
        /** 字典标签 */
        [Column(Name = "dict_type", DbType = "varchar(100)")]
        public String DictType { get; set; }
        /** 状态（0正常 1停用） */
        [Column(Name = "status", DbType = "char(1)")]
        public String Status { get; set; }
        /** 备注 */
        [Column(Name = "remark", DbType = "varchar(500)")]
        public String Remark { get; set; }
    }
}
