using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;

namespace MaiziWPF.Services.Application
{
    public class SysRoleService : ISysRoleService
    {
        private readonly ISysRoleRepository _repository;

        public SysRoleService(ISysRoleRepository repository)
        {
            _repository = repository;
        }

        public List<SysRole> SelectRoleList(QueryRoleInput input)
        {
            return _repository.SelectRoleList(input);
        }
    }
}
