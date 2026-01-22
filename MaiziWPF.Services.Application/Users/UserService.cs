using MaiziWPF.Services.Application.Contracts.Users;
using MaiziWPF.Services.Domain.Users;

namespace MaiziWPF.Services.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)

        {
            _repository = repository;
        }
        public void GetUser()
        {
        }
    }
}
