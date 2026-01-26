using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 字典数据表 sys_dict_data
    /// 注意：与原表有差异
    /// </summary>
    public class SysDictData: BaseEntity
    {
        /** 字典编码 */
        public Int64 DictCode { get; set; }
        /** 字典排序 */
        public Int64 DictSort { get; set; }
        /** 字典标签 */
        public String DictLabel { get; set; }
        /** 字典键值 */
        public String DictValue { get; set; }
        /** 字典类型 */
        public String DictType { get; set; }
        /** 是否默认（Y是 N否） */
        public String IsDefault { get; set; }
        /** 状态（0正常 1停用） */
        public String Status { get; set; }
        /** 备注 */
        public String Remark { get; set; }
    }
}
