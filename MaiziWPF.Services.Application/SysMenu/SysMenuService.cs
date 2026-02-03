using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Application
{
    public class SysMenuService : ISysMenuService
    {
        private readonly ISysMenuRepository _repository;

        public SysMenuService(ISysMenuRepository repository)

        {
            _repository = repository;
        }

        public List<SysMenu> SelectMenuTreeAll()
        {
            return _repository.SelectMenuTreeAll();
        }
    }
}
