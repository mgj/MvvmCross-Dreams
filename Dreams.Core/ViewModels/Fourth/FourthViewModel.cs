using Dreams.Core.Services.DreamsWeb;
using Dreams.Core.ViewModels.Common;
using Dreams.Core.ViewModels.Fifth;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreams.Core.ViewModels.Fourth
{
    public class FourthViewModel : DreamsViewModelBase
    {
        /// <summary>
        /// Purpose: Show how to display a burger menu
        /// </summary>
        public FourthViewModel()
        {

        }

        private MvxCommand _showFifthCommand;

        public MvxCommand ShowFifthCommand
        {
            get
            {
                _showFifthCommand = _showFifthCommand ?? new MvxCommand(DoShowSecondCommand);
                return _showFifthCommand;
            }
        }

        private void DoShowSecondCommand()
        {
            ShowViewModel<FifthViewModel>();
        }
    }
}
