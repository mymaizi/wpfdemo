using FreeSql;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain.Users
{
    public interface IUserRepository: IBaseRepository<User,int>, ITransientDependency
    {
        void GetUser();
    }
}
