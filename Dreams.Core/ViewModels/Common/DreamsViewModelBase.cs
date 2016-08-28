using artm.MvxPlugins.Logger.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Dreams.Core.ViewModels.Common
{
    public abstract class DreamsViewModelBase : MvxViewModel
    {
        private readonly ILoggerService _log;

        public DreamsViewModelBase()
        {
            // Constructor injection is generally preferred
            // but if we did it in this base class we would
            // force all children to adjust their constructor
            _log = Mvx.Resolve<ILoggerService>();
        }

        public ILoggerService Log
        {
            get
            {
                return _log;
            }
        }
    }
}
