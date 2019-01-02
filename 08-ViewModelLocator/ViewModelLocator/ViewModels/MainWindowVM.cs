using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLocator.ViewModels
{
    using Prism.Mvvm;

    class MainWindowVM : BindableBase
    {
        private string _title = "new ViewModel";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowVM()
        {

        }
    }
}
