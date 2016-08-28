using artm.MvxPlugins.Fetcher.Services;
using Dreams.Core.Services.DreamsWeb;
using Dreams.Core.ViewModels.Fifth;
using Dreams.Core.ViewModels.First;
using Dreams.Core.ViewModels.Fourth;
using MvvmCross.Platform;

namespace Dreams.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            Mvx.ConstructAndRegisterSingleton<IFetcherService, FetcherService>();
            Mvx.ConstructAndRegisterSingleton<IDreamsWebService, DreamsWebService>();

            RegisterAppStart<FirstViewModel>();
        }
    }
}
