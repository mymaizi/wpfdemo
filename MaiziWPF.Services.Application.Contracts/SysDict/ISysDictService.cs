using MaiziWPF.Services.Domain;
using Volo.Abp.DependencyInjection;

namespace MaiziWPF.Services.Application.Contracts
{
    public interface ISysDictService: ITransientDependency
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
