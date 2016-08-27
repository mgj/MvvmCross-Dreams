using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using Dreams.Droid.Services.Logger;
using Dreams.Core.Services.DreamsLog;
using Dreams.Core.Services.Dialog;
using Dreams.Droid.Services.Dialog;

namespace Dreams.Droid
{
    public class Setup : MvxAndroidSetup
    {
        private Context _applicationContext;

        public Setup(Context applicationContext)
            : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.RegisterSingleton<IDreamsLogService>(() => new DreamsLogService(_applicationContext));
            Mvx.Resolve<IDreamsLogService>(); // Trigger creation of singleton

            Mvx.ConstructAndRegisterSingleton<IDialogService, DialogService>();
        }
    }
}
