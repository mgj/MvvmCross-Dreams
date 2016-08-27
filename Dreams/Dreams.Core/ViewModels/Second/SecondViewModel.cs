using Dreams.Core.ViewModels.Common;
using System.Linq;
using Dreams.Core.Services.DreamsWeb;
using MvvmCross.Core.ViewModels;
using Dreams.Core.ViewModels.Third;

namespace Dreams.Core.ViewModels.Second
{
    /// <summary>
    /// Purpose: Show how to receive data passed by ShowViewModel.
    /// Show how to initialize the viewmodel using an async method
    /// (fetching data from the network or database)
    /// </summary>
    public class SecondViewModel : DreamsViewModelBase
    {
        private readonly IDreamsWebService _webService;

        public SecondViewModel(IDreamsWebService webService)
        {
            _webService = webService;
            _webService.FetchAsync().ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    SecondData = "Fetched data from webservice: " + t.Result.Count;
                }
                else
                {
                    SecondData = "Fetching from webservice failed!";
                }
            });
        }

        // Called by MvvmCross when we init this
        // viewmodel with ShowViewModel(new SecondViewBundle()...);
        public void Init(SecondViewModelBundle bundle)
        {
            Log.Log("Initializing with data: " + bundle.Data);
            if(string.IsNullOrEmpty(SecondData) == true)
            {
                SecondData = bundle.Data;
            }
        }

        private string _secondData;

        public string SecondData
        {
            get { return _secondData; }
            set { SetProperty(ref _secondData, value, "SecondData"); }
        }

        private MvxCommand _showThirdCommand;

        public MvxCommand ShowThirdCommand
        {
            get
            {
                _showThirdCommand = _showThirdCommand ?? new MvxCommand(DoShowThirdCommand);
                return _showThirdCommand;
            }
        }

        private void DoShowThirdCommand()
        {
            ShowViewModel<ThirdViewModel>();
        }
    }
}
