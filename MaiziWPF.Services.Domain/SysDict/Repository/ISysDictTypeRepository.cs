using FreeSql;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysDictTypeRepository : IBaseRepository<SysDictType, int>, ITransientDependency
    {
        /**
         * 根据字典类型查询字典数据
         * 
         * @param dictType 字典类型
         * @return 字典数据集合信息
         */
        public List<SysDictData> SelectDictDataByType(String dictType);
        /**
       * 根据条件分页查询字典类型
       * 
       * @param dictType 字典类型信息
       * @return 字典类型集合信息
       */
        public List<SysDictType> SelectDictTypeList(QueryDictTypeInput input);
    }
}
