using MaiziWPF.Services.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Modularity;
using Volo.Abp.Studio;

namespace MaiziWPF.Services.MySql
{
    [DependsOn(
        typeof(DomainModule)
    )]
    public class MySqlModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IFreeSql>(r =>
            {
                IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                    .UseConnectionString(FreeSql.DataType.MySql, "Data Source=127.0.0.1;Port=3306;User ID=root;Password=; Initial Catalog=maiziwpf;Charset=utf8mb4; SslMode=none;Min pool size=1")
                    .UseMonitorCommand(cmd =>
                    {
                        var logger = r.GetRequiredService<ILogger<MySqlModule>>();
                        logger.LogInformation(cmd.CommandText);
                    })
                    .UseAutoSyncStructure(true)
                    .Build();
                return fsql;
            });
            context.Services.AddFreeRepository();
        }
    }
}
