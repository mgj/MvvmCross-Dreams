using Android.OS;
using Dreams.Core.ViewModels.Common;
using Dreams.Core.Common;
using MvvmCross.Platform;
using MvvmCross.Binding.BindingContext;
using Dreams.Core.Services.DreamsLog;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.Widget;

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

        private IDreamsLogService _log;

        protected IDreamsLogService Log
        {
            get
            {
                if (_log == null && Mvx.CanResolve<IDreamsLogService>())
                {
                    _log = Mvx.Resolve<IDreamsLogService>();
                }

                return _log;
            }
        }
    }
}