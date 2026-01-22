using MaiziWPF.Services.Application;
using MaiziWPF.Services.MySql;
using Volo.Abp.Modularity;

namespace MaiziWPF
{
    [DependsOn(typeof(ApplicationModule), typeof(MySqlModule))]
    public class MaiziWPFModule : AbpModule
    {
      
    }
}
