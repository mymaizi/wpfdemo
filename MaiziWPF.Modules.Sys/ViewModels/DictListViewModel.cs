using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiziWPF.Modules.Sys
{
    public class DictListViewModel : PageBindableBase<SysDictType, QueryDictTypeInput>
    {
        private readonly ISysDictService _dictService;
        public DictListViewModel(ISysDictService dictService)
        {
            _dictService = dictService;
            RegisterQueryFunc(input =>
            {
                return _dictService.SelectDictTypeList(input);
            }, new QueryDictTypeInput() { PageNumber = 1, PageSize = 10 });
            SearchButtonCommand.Execute(this);
        }
    }
}
