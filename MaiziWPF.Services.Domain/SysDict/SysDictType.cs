using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 字典类型表 sys_dict_type
    /// 注意：与原表有差异
    /// </summary>
    public class SysDictType: BaseEntity
    {
        /** 字典编码 */
        public Int64 DictId { get; set; }
        /** 字典排序 */
        public Int64 DictName { get; set; }
        /** 字典标签 */
        public String DictType { get; set; }
        /** 状态（0正常 1停用） */
        public String Status { get; set; }
        /** 备注 */
        public String Remark { get; set; }
    }
}
