using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 菜单表
    /// 注意：与原表有差异
    /// </summary>
    public class SysMenu: BaseEntity
    {
        /** 部门ID */
        public Int64 MenuId { get; set; }
        /** 父部门ID */
        public String MenuName { get; set; }
        /** 祖级列表 */
        public String ParentName { get; set; }
        /** 部门名称 */
        public Int64 ParentId { get; set; }
        /** 显示顺序 */
        public Int32 OrderNum { get; set; }
        /** 负责人 */
        public String MenuType { get; set; }
        /** 联系电话 */
        public String Visible { get; set; }
        /** 邮箱 */
        public String Status { get; set; }
        /** 删除标志（0代表存在 2代表删除） */
        public String Perms { get; set; }
        /** 父部门名称 */
        public String Icon { get; set; }
        /** 备注 */
        public String Remark { get; set; }
        /** 子部门 */
        public List<SysMenu> Children { get; set; }
    }
}

