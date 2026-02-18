using FreeSql.DataAnnotations;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    public class BaseEntity
    {
        /** 创建者 */
        [Column(Name = "create_by", DbType = "varchar(64)")]
        public String CreateBy { get; set; }
        /** 创建时间 */
        [Column(Name = "create_time")]
        public DateTime CreateTime { get; set; }
        /** 更新者 */
        [Column(Name = "update_by", DbType = "varchar(64)")]
        public String UpdateBy { get; set; }
        /** 更新时间 */
        [Column(Name = "update_time")]
        public DateTime UpdateTime { get; set; }
        /** 删除标志（0代表存在 2代表删除） */
        [Column(Name = "del_flag", DbType = "char(1)")]
        public String DelFlag { get; set; }
  
    }
}
