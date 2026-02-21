using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using MaiziWPF.Services.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Application
{
    public class SysPostService : ISysPostService
    {
        private readonly ISysPostRepository _repository;

        public SysPostService(ISysPostRepository repository)
        {
            _repository = repository;
        }
        public List<SysPost> SelectPostList(QueryPostInput post)
        {
          return _repository.SelectPostList(post);
        }
    }
}
