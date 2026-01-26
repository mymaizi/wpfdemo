using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 部门表 sys_dept
    /// </summary>
    public class SysDept: BaseEntity
    {
        /** 部门ID */
        public Int64 DeptId { get; set; }
        /** 父部门ID */
        public Int64 ParentId { get; set; }
        /** 祖级列表 */
        public String Ancestors { get; set; }
        /** 部门名称 */
        public String DeptName { get; set; }
        /** 显示顺序 */
        public Int32 OrderNum { get; set; }
        /** 负责人 */
        public String Leader { get; set; }
        /** 联系电话 */
        public String Phone { get; set; }
        /** 邮箱 */
        public String Email { get; set; }
        /** 删除标志（0代表存在 2代表删除） */
        public String Status { get; set; }
        /** 父部门名称 */
        public String ParentName { get; set; }
        /** 子部门 */
        public List<SysDept> Children { get; set; }
    }
}
