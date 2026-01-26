using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    ///  角色表 sys_role
    ///  注意：与原表有差异
    /// </summary>
    public class SysRole:BaseEntity
    {
        /** 角色ID */
        public Int64 RoleId { get; set; }
        /** 角色名称 */
        public String RoleName { get; set; }
        /** 角色权限 */
        public String RoleKey { get; set; }
        /** 角色权限 */
        public String RoleSort { get; set; }
        /** 数据范围（1：所有数据权限；2：自定义数据权限；3：本部门数据权限；4：本部门及以下数据权限；5：仅本人数据权限） */
        public String DataScope { get; set; }
        /** 角色状态（0正常 1停用） */
        public String Status { get; set; }
        /** 备注 */
        public String Remark { get; set; }
    }
}
