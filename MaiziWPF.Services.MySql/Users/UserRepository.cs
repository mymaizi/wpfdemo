using FreeSql;
using MaiziWPF.Services.Domain.Users;

namespace MaiziWPF.Services.MySql.Users
{

    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        private readonly IFreeSql _fsql;

        public UserRepository(IFreeSql fsql) : base(fsql)
        {
            _fsql = fsql;
        }

        public void GetUser()
        {
            
        }
    }
}
