using System.Xml.Linq;

namespace MaiziWPF.Services.Domain
{
    /// <summary>
    /// 用户表 sys_user
    /// </summary>
    public class SysUser : BaseEntity
    {
        /** 用户ID */
        public Int64 UserId { get; set; }
        /** 用户账号 */
        public String UserName { get; set; }
        /** 用户昵称 */
        public String NickName { get; set; }
        /** 用户邮箱 */
        public String Email { get; set; }
        /** 手机号码 */
        public String Phonenumber { get; set; }
        /** 用户性别 */
        public String Sex { get; set; }
        /** 用户头像 */
        public String Avatar { get; set; }
        /** 密码 */
        public String Password { get; set; }
        /** 账号状态（0正常 1停用） */
        public String Status { get; set; }
        /** 最后登录IP */
        public String LoginIp { get; set; }
        /** 最后登录时间 */
        public DateTime LoginDate { get; set; }
        /** 密码最后更新时间 */
        public DateTime PwdUpdateDate { get; set; }
        /** 备注 */
        public String Remark { get; set; }
        /** 部门对象 */
        public List<SysDept> Depts{ get; set; }
        /** 角色对象 */
        public List<SysRole> Roles{ get; set; }
        /** 岗位对象 */
        public List<SysPost> Posts { get; set; }
    }
}
