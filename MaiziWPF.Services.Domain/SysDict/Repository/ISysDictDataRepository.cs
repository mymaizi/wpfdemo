using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Domain
{
    public interface ISysDictDataRepository : IBaseRepository<SysDictData, int>, ITransientDependency
    {
        /**
         * 根据字典类型查询字典数据
         * 
         * @param dictType 字典类型
         * @return 字典数据集合信息
         */
        public List<SysDictData> SelectDictDataByType(String dictType);
    }
}
