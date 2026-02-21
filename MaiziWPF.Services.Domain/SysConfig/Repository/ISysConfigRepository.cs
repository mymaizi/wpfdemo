using FreeSql;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysConfigRepository : IBaseRepository<SysConfig, int>, ITransientDependency
    {
        /**
        * 查询参数配置列表
        * 
        * @param config 参数配置信息
        * @return 参数配置集合
        */
        public List<SysConfig> SelectConfigList(QueryConfigInput input);
    }
}
