using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Application
{
    public class SysConfigService:ISysConfigService
    {
        private readonly ISysConfigRepository _repository;

        public SysConfigService(ISysConfigRepository repository)
        {
            _repository = repository;
        }

        /**
       * 查询参数配置列表
       * 
       * @param config 参数配置信息
       * @return 参数配置集合
       */
        public List<SysConfig> SelectConfigList(QueryConfigInput input)
        {
            return _repository.SelectConfigList(input);
        }
    }
}
