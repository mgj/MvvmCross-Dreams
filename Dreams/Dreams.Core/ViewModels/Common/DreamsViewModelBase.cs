using Dreams.Core.Services.DreamsLog;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Dreams.Core.ViewModels.Common
{
    public abstract class DreamsViewModelBase : MvxViewModel
    {
        private readonly IDreamsLogService _log;

        public DreamsViewModelBase()
        {
            // Constructor injection is generally preferred
            // but if we did it in this base class we would
            // force all children to adjust their constructor
            _log = Mvx.Resolve<IDreamsLogService>();
        }

        public IDreamsLogService Log
        {
            get
            {
                return _log;
            }
        }
    }
}
