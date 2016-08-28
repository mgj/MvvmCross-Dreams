using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using Dreams.Core.Services.Dialog;
using Dreams.Droid.Services.Dialog;
using artm.MvxPlugins.Logger.Services;
using artm.MvxPlugins.Logger.Droid.Services;

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

            Mvx.ConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.RegisterSingleton<ILoggerService>(() => new LoggerService(_applicationContext));
        }
    }
}
