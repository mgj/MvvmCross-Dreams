using Dreams.Core.Services.DreamsWeb;
using Dreams.Core.ViewModels.Common;
using Dreams.Core.ViewModels.Fourth;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreams.Core.ViewModels.Third
{
    // Purpose: To show how lists can be used
    public class ThirdViewModel : DreamsViewModelBase
    {
        private readonly IDreamsWebService _webService;

        public ThirdViewModel(IDreamsWebService webService)
        {
            _webService = webService;
            _webService.FetchAsync().ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    Data = new ObservableCollection<DreamsWebServiceDTO>(t.Result);
                }
                else
                {
                }
            });
        }

        private ObservableCollection<DreamsWebServiceDTO> _data = new ObservableCollection<DreamsWebServiceDTO>();

        public ObservableCollection<DreamsWebServiceDTO> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value, "Data"); }
        }

        private DreamsWebServiceDTO _selectedItem;
        public DreamsWebServiceDTO SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value, "SelectedItem"); }
        }

        private MvxCommand<DreamsWebServiceDTO> _itemSelectedCommand;
        public MvxCommand<DreamsWebServiceDTO> ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<DreamsWebServiceDTO>(item => DoItemSelectedCommand(item));
                return _itemSelectedCommand;
            }
        }

        private void DoItemSelectedCommand(DreamsWebServiceDTO item)
        {
            ShowViewModel<FourthViewModel>();
        }
    }
}
