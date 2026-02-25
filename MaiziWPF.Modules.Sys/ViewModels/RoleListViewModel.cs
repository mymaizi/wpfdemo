using MaiziWPF.Core;
using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Input;

namespace MaiziWPF.Modules.Sys
{
    public class RoleListViewModel : PageBindableBase<SysRole,QueryRoleInput>
    {
        private readonly ISysRoleService _roleService;
        public RoleListViewModel(ISysRoleService roleService)
        {
            _roleService = roleService;
            RegisterQueryFunc(input =>
            {
                return _roleService.SelectRoleList(input);
            }, new QueryRoleInput() { PageNumber = 1, PageSize = 10 });
            SearchButtonCommand.Execute(this);
        }
      
    }
}
