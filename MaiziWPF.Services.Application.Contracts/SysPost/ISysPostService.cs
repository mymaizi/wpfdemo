using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts
{
    public interface ISysPostService: ITransientDependency
    {
        /**
         * 查询岗位信息集合
         * 
         * @param post 岗位信息
         * @return 岗位列表
         */
        public List<SysPost> SelectPostList(QueryPostInput post);
    }
}
