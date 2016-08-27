using Dreams.Core.ViewModels.Common;
using Dreams.Core.ViewModels.Second;
using MvvmCross.Core.ViewModels;

namespace Dreams.Core.ViewModels.First
{
    /// <summary>
    /// Purpose: To show how to do simple data binding, as well
    /// as navigation between viewmodels (which can include
    /// passing data)
    /// </summary>
    public class FirstViewModel
        : DreamsViewModelBase
    {
        private string _hello = string.Empty;

        public FirstViewModel()
        {
        }

        public string Hello
        {
            get
            {
                return _hello;
            }

            set
            {
                SetProperty(ref _hello, value, "Hello");
                Log.Log("Setting Hello to: " + value);
            }
        }

        private MvxCommand _showSecondCommand;

        public MvxCommand ShowSecondCommand
        {
            get
            {
                _showSecondCommand = _showSecondCommand ?? new MvxCommand(DoShowSecondCommand);
                return _showSecondCommand;
            }
        }

        private void DoShowSecondCommand()
        {
            ShowViewModel<SecondViewModel>(new SecondViewModelBundle() { Data = "Hello from FirstView - " + Hello });
        }
    }
}
