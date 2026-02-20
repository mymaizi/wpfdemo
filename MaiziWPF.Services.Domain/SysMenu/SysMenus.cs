using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 菜单表
    /// 注意：与原表有差异
    /// </summary>
    [Table(Name ="sys_menu")]
    public class SysMenu: BaseEntity
    {
        /** 菜单ID */
        [Column(Name = "menu_id", IsIdentity = true, IsPrimary = true)]
        public Int64 Id { get; set; }
        /** 菜单名称 */
        [Column(Name = "menu_name",DbType = "varchar(50)")]
        public String MenuName { get; set; }
        /** 父菜单ID */
        [Column(Name = "parent_id")]
        public Int64 ParentId { get; set; }
        /** 显示顺序 */
        [Column(Name = "order_num")]
        public Int32 OrderNum { get; set; }
        /** 菜单类型（M目录 C菜单 F按钮） */
        [Column(Name = "menu_type", DbType = "char(1)")]
        public String MenuType { get; set; }
        /** 菜单状态（0正常 1停用） */
        [Column(Name = "status", DbType = "char(1)")]
        public String Status { get; set; }
        /** 权限标识 */
        [Column(Name = "perms", DbType = "varchar(100)")]
        public String Perms { get; set; }
        /** 菜单图标 */
        [Column(Name = "icon", DbType = "varchar(100)")]
        public String Icon { get; set; }
        /** 备注 */
        [Column(Name = "remark", DbType = "varchar(500)")]
        public String Remark { get; set; }
        /** 层级 */
        [Column(Name = "level")]
        public Int32 Level { get; set; }
        /** 视图路径 */
        [Column(Name = "component", DbType = "varchar(255)")]
        public String Component { get; set; }
        /** 视图参数 */
        [Column(Name = "query", DbType = "varchar(255)")]
        public String Query { get; set; }
        [Navigate(nameof(ParentId))]
        public List<SysMenu> Childs { get; set; }
    }
}

