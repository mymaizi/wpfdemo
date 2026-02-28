using FreeSql;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;

namespace MaiziWPF.Services.Application
{
    public class SysUserService : ISysUserService
    {
        private readonly ISysUserRepository _repository;

        public SysUserService(ISysUserRepository repository)
        {
            _repository = repository;
        }
        [Transactional]
        public long InsertUser(SysUser user)
        {
            // 新增用户信息
            long userId = _repository.InsertUser(user);
            user.UserId = userId;
            // 新增用户岗位关联
            //InsertUserPost(user);
            // 新增用户与角色管理
            //InsertUserRole(user);
            // 新增用户与部门管理
            //InsertUserDept(user);
            return userId;
        }
        /**
          * 新增用户岗位信息
          * 
          * @param user 用户对象
          */
        public void InsertUserPost(SysUser user)
        {
            if (user.Posts!=null&&user.Posts.Any())
            {
                // 新增用户与岗位管理
                List<SysUserPost> list = new();
                user.Posts.ForEach(post =>
                {
                    SysUserPost up = new SysUserPost();
                    up.UserId = user.UserId;
                    up.PostId = post.PostId;
                    list.Add(up);
                });
                _repository.BatchUserPost(list);
            }
        }
        /**
        * 新增用户角色信息
        * 
        * @param userId 用户ID
        * @param roleIds 角色组
        */
        public void InsertUserRole(SysUser user)
        {
            if (user.Roles != null && user.Roles.Any())
            {
                // 新增用户与岗位管理
                List<SysUserRole> list = new();
                user.Roles.ForEach(role =>
                {
                    SysUserRole ur = new SysUserRole();
                    ur.UserId = user.UserId;
                    ur.RoleId = role.RoleId;
                    list.Add(ur);
                });
                _repository.BatchUserRole(list);
            }
        }
        /**
         * 新增用户部门信息
         * 
         * @param user 用户对象
         */
        public void InsertUserDept(SysUser user)
        {
            if (user.Depts != null && user.Depts.Any())
            {
                // 新增用户与岗位管理
                List<SysUserDept> list = new();
                user.Depts.ForEach(post =>
                {
                    SysUserDept up = new SysUserDept();
                    up.UserId = user.UserId;
                    up.DeptId = post.Id;
                    list.Add(up);
                });
                _repository.BatchUserDept(list);
            }
        }

        public SysUser SelectUserByUserName(string userName)
        {
           return _repository.SelectUserByUserName(userName);
        }

        public List<SysUser> SelectUserList(QueryUserInput input)
        {
            return _repository.SelectUserList(input);
        }
    }
}
