using MaiziWPF.Core;
using MaiziWPF.Services.Application;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiziWPF.Modules.Sys
{
    public class ConfigListViewModel : PageBindableBase<SysConfig, QueryConfigInput>
    {
        private readonly ISysConfigService _configService;
        public ConfigListViewModel(ISysConfigService configService, IDialogService dialogService) :base(dialogService)
        {
            _configService = configService;
            RegisterQueryFunc(input =>
            {
                return _configService.SelectConfigList(input);
            }, new QueryConfigInput() { PageNumber = 1, PageSize = 10 });
            SearchButtonCommand.Execute(this);
        }
    }
}
