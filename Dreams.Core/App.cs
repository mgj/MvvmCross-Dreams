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
            Mvx.LazyConstructAndRegisterSingleton<IDreamsWebService, DreamsWebService>();

            RegisterAppStart<FirstViewModel>();
        }
    }
}
