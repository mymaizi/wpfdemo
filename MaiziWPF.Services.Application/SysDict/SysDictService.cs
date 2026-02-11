using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Application
{
    public class SysDictService : ISysDictService
    {
        private readonly ISysDictDataRepository _repository;

        public SysDictService(ISysDictDataRepository repository)
        {
            _repository = repository;
        }

        public List<SysDictData> SelectDictDataByType(string dictType)
        {
          return _repository.SelectDictDataByType(dictType);
        }
    }
}
