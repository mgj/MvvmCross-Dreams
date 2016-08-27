using Dreams.Core.Services.Dialog;
using Dreams.Core.ViewModels.Common;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreams.Core.ViewModels.Fifth
{
    /// <summary>
    /// Purpose: To show dialog usage
    /// </summary>
    public class FifthViewModel : DreamsViewModelBase
    {
        private readonly IDialogService _dialogService;

        public FifthViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private MvxCommand _infoCommand;
        public MvxCommand InfoCommand
        {
            get
            {
                _infoCommand = _infoCommand ?? new MvxCommand(DoInfoCommand);
                return _infoCommand;
            }
        }

        private void DoInfoCommand()
        {
            _dialogService.Info("Info clicked");
        }

        private MvxAsyncCommand _loadingWithProgressCommand;
        public MvxAsyncCommand LoadingWithProgressCommand
        {
            get
            {
                _loadingWithProgressCommand = _loadingWithProgressCommand ?? new MvxAsyncCommand(DoLoadingWithProgressCommandAsync);
                return _loadingWithProgressCommand;
            }
        }

        private async Task DoLoadingWithProgressCommandAsync()
        {
            const int DELAY = 100;
            _dialogService.ShowLoading("Loading...", true);

            for (int i = 0; i <= DELAY; i++)
            {
                await Task.Delay(1);
                if(i == 20)
                {
                    await Task.Delay(1000);
                }
                _dialogService.LoadingProgress(i);
            }
        }

        private MvxAsyncCommand _loadingCommand;
        public MvxAsyncCommand LoadingCommand
        {
            get
            {
                _loadingCommand = _loadingCommand ?? new MvxAsyncCommand(DoLoadingCommandAsync);
                return _loadingCommand;
            }
        }

        private async Task DoLoadingCommandAsync()
        {
            const int DELAY = 100;
            _dialogService.ShowLoading("Loading...");

            for (int i = 0; i <= DELAY; i++)
            {
                await Task.Delay(1);
                _dialogService.LoadingProgress(i);
            }
        }
    }
}
