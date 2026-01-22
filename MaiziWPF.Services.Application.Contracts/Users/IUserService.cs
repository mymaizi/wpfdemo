using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts.Users
{
    public interface IUserService: ITransientDependency
    {
        void GetUser();
    }
}
