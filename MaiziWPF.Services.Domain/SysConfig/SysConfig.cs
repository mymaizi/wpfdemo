using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    [Table(Name = "sys_config")]
    public class SysConfig:BaseEntity
    {
        /** 参数主键 */
        [Column(Name = "config_id", IsIdentity = true, IsPrimary = true)]
        public Int64 ConfigId { get; set; }
        /** 参数主键 */
        [Column(Name = "config_name", DbType = "varchar(100)")]
        public String ConfigName { get; set; }
        /** 参数主键 */
        [Column(Name = "config_key", DbType = "varchar(100)")]
        public String ConfigKey { get; set; }
        /** 参数主键 */
        [Column(Name = "config_value", DbType = "varchar(500)")]
        public String ConfigValue { get; set; }
        /** 参数主键 */
        [Column(Name = "config_type", DbType = "char(1)")]
        public String ConfigType { get; set; }
        /** 备注 */
        [Column(Name = "remark", DbType ="varchar(500)")]
        public String Remark { get; set; }
    }
}
