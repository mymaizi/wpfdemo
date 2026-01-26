using MaiziWPF.Services.Domain.Shared;
using Volo.Abp.Modularity;

namespace MaiziWPF.Services.Domain
{
    [DependsOn(
        typeof(DomainSharedModule)
   )]
    public class DomainModule: AbpModule
    {
    }
}
