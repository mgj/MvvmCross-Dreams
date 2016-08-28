using Android.OS;
using Dreams.Core.ViewModels.Common;
using Dreams.Core.Common;
using MvvmCross.Platform;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.Widget;
using artm.MvxPlugins.Logger.Services;

namespace Dreams.Droid.Views.Common
{
    public abstract class DreamsViewBase<TView, TViewModel> : MvxCachingFragmentCompatActivity
        where TView : DreamsViewBase<TView, TViewModel>
        where TViewModel : DreamsViewModelBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Title = DreamsResources.Common_Application_Label;

            SetContentView(ResourceLayoutId);
            PrepareToolbar();

            var thisAsPage = this as TView;
            BindingSet = thisAsPage.CreateBindingSet<TView, TViewModel>();
        }

        protected override void OnResume()
        {
            base.OnResume();
            OverridePendingTransition(Resource.Animation.fadein, Resource.Animation.fadeout);
        }

        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.fadein, Resource.Animation.fadeout);
        }

        private void PrepareToolbar()
        {
            var hero = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (hero != null)
            {
                SetSupportActionBar(hero);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }

        protected MvxFluentBindingDescriptionSet<TView, TViewModel> BindingSet
        {
            get;
            private set;
        }

        protected abstract int ResourceLayoutId
        {
            get;
        }

        private ILoggerService _log;

        protected ILoggerService Log
        {
            get
            {
                if (_log == null && Mvx.CanResolve<ILoggerService>())
                {
                    _log = Mvx.Resolve<ILoggerService>();
                }

                return _log;
            }
        }
    }
}