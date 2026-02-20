using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaiziWPF.Core
{
    public class PageBindableBase: BindableBase
    {
        private int _pageNumber;
        public int PageNumber { get => _pageNumber; set => SetProperty(ref _pageNumber, value); }
        private int _pageSize;
        public int PageSize { get => _pageSize; set => SetProperty(ref _pageSize, value); }
        private long _count;
        public long Count { get => _count; set => SetProperty(ref _count, value); }

        public ICommand SearchButtonCommand { get; set; }
        public ICommand PrevButtonCommand { get; set; }
        public ICommand NextButtonCommand { get; set; }
    }
}
