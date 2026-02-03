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
        [Column(Name = "menu_name")]
        public String MenuName { get; set; }
        /** 父菜单ID */
        [Column(Name = "parent_id")]
        public Int64 ParentId { get; set; }
        /** 显示顺序 */
        [Column(Name = "order_num")]
        public Int32 OrderNum { get; set; }
        /** 菜单类型（M目录 C菜单 F按钮） */
        [Column(Name = "menu_type")]
        public String MenuType { get; set; }
        /** 菜单显示状态（0显示 1隐藏） */
        [Column(Name = "visible")]
        public String Visible { get; set; }
        /** 菜单状态（0正常 1停用） */
        [Column(Name = "status")]
        public String Status { get; set; }
        /** 权限标识 */
        [Column(Name = "perms")]
        public String Perms { get; set; }
        /** 菜单图标 */
        [Column(Name = "icon")]
        public String Icon { get; set; }
        /** 备注 */
        [Column(Name = "remark")]
        public String Remark { get; set; }
        /** 层级 */
        [Column(Name = "level")]
        public Int32 Level { get; set; }
        /** 视图路径 */
        [Column(Name = "component")]
        public String Component { get; set; }
        /** 视图参数 */
        [Column(Name = "query")]
        public String Query { get; set; }
        [Navigate(nameof(ParentId))]
        public List<SysMenu> Childs { get; set; }
    }
}

