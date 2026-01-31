using MaiziWPF.Services.Domain;
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
    }
}
