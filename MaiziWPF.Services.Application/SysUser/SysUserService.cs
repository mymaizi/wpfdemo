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
