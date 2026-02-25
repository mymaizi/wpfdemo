using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Application
{
    public class SysDeptService : ISysDeptService
    {
        private readonly ISysDeptRepository _repository;

        public SysDeptService(ISysDeptRepository repository)

        {
            _repository = repository;
        }

        public List<SysDept> SelectDeptList(SysDept dept, bool isTreeQuery = true)
        {
           return _repository.SelectDeptList(dept, isTreeQuery);
        }
    }
}
