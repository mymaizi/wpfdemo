using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 部门表 sys_dept
    /// </summary>
    [Table(Name = "sys_dept")]
    public class SysDept: BaseEntity
    {
        /** 部门ID */
        [Column(Name = "dept_id", IsIdentity = true, IsPrimary = true)]
        public Int64 DeptId { get; set; }
        /** 父部门ID */
        [Column(Name = "parent_id")]
        public Int64 ParentId { get; set; }
        /** 祖级列表 */
        [Column(Name = "ancestors")]
        public String Ancestors { get; set; }
        /** 部门名称 */
        [Column(Name = "dept_name")]
        public String DeptName { get; set; }
        /** 显示顺序 */
        [Column(Name = "order_num")]
        public Int32 OrderNum { get; set; }
        /** 负责人 */
        [Column(Name = "leader")]
        public String Leader { get; set; }
        /** 联系电话 */
        [Column(Name = "phone")]
        public String Phone { get; set; }
        /** 邮箱 */
        [Column(Name = "email")]
        public String Email { get; set; }
        /** 删除标志（0代表存在 2代表删除） */
        [Column(Name = "status")]
        public String Status { get; set; }
        /** 父部门 */
        [Navigate(nameof(ParentId))]
        public SysDept Parent { get; set; }
        /** 子部门 */
        [Navigate(nameof(ParentId))]
        public List<SysDept> Children { get; set; }
    }
}
