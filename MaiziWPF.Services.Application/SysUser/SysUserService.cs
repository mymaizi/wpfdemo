using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;

namespace MaiziWPF.Services.Application
{
    public class SysUserService : ISysUserService
    {
        private readonly ISysUserRepository _repository;

        public SysUserService(ISysUserRepository repository)

        {
            _repository = repository;
        }
    }
}
