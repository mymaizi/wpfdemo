using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts
{
    public interface ISysUserService: ITransientDependency
    {
        /**
        * 通过用户名查询用户
        * 
        * @param userName 用户名
        * @return 用户对象信息
        */
        public SysUser SelectUserByUserName(String userName);
        /**
        * 根据条件分页查询用户列表
        * 
        * @param user 用户信息
        * @return 用户信息集合信息
        */
        public List<SysUser> SelectUserList(QueryUserInput input);
        /**
        * 新增用户信息
        * 
        * @param user 用户信息
        * @return 结果
        */
        public long InsertUser(SysUser user);
        
        /**
        * 删除用户信息
        * 
        * @param userId 用户ID
        * @return 结果
        */
        public bool DeleteUser(long userId);
        
        /**
        * 修改用户信息
        * 
        * @param user 用户信息
        * @return 结果
        */
        public bool UpdateUser(SysUser user);
    }
}
