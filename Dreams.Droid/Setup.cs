using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using artm.MvxPlugins.Logger.Services;
using artm.MvxPlugins.Logger.Droid.Services;
using artm.MvxPlugins.Dialog.Services;
using artm.MvxPlugins.Dialog.Droid.Services;

namespace Dreams.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
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
            Mvx.RegisterSingleton<ILoggerService>(() => new LoggerService(ApplicationContext));
        }
    }
}
