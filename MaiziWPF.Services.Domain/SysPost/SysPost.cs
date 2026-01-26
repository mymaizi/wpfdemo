using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 岗位信息表 sys_post
    /// 注意：与原表有差异
    /// </summary>
    public class SysPost: BaseEntity
    {
        /** 岗位序号 */
        public Int64 PostId { get; set; }
        /** 用户ID */
        public String PostCode { get; set; }
        /** 用户ID */
        public String PostName { get; set; }
        /** 用户ID */
        public Int32 PostSort { get; set; }
        /** 状态（0正常 1停用） */
        public String Status { get; set; }
        /** 备注 */
        public String Remark { get; set; }
    }
}
