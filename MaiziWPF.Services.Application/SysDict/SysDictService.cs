using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Application
{
    public class SysDictService : ISysDictService
    {
        private readonly ISysDictTypeRepository _repository;

        public SysDictService(ISysDictTypeRepository repository)
        {
            _repository = repository;
        }

        public List<SysDictData> SelectDictDataByType(string dictType)
        {
          return _repository.SelectDictDataByType(dictType);
        }

        public List<SysDictType> SelectDictTypeList(QueryDictTypeInput input)
        {
            return _repository.SelectDictTypeList(input);
        }
    }
}
