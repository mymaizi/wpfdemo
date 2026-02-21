using FreeSql;
using MaiziWPF.Services.Domain.Shared;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysPostRepository : IBaseRepository<SysPost, int>, ITransientDependency
    {
        /**
        * 查询岗位数据集合
        * 
        * @param post 岗位信息
        * @return 岗位数据集合
        */
        public List<SysPost> SelectPostList(QueryPostInput input);

     
    }
}
