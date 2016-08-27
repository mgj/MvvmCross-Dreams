using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Dreams.Core.ViewModels.Fifth;
using Dreams.Droid.Views.Common;
using Dreams.Core.Common;

namespace Dreams.Droid.Views.Fifth
{
    [Activity]
    public class FifthView : DreamsViewBase<FifthView, FifthViewModel>
    {
        protected override int ResourceLayoutId
        {
            get
            {
                return Resource.Layout.activity_fifthview;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            PrepareUI();
        }

        private void PrepareUI()
        {
            PrepareInfoButton();
            PrepareLoadingButton();
            PrepareLoadingWithProgressButton();
        }

        private void PrepareLoadingWithProgressButton()
        {
            var hero = FindViewById<Button>(Resource.Id.fifthview_loading_withprogress_button);
            hero.Text = DreamsResources.FifthView_LoadingWithProgress_Button_label;
            BindingSet.Bind(hero).To(vm => vm.LoadingWithProgressCommand);
            BindingSet.Apply();
        }

        private void PrepareLoadingButton()
        {
            var hero = FindViewById<Button>(Resource.Id.fifthview_loading_button);
            hero.Text = DreamsResources.FifthView_Loading_Button_label;
            BindingSet.Bind(hero).To(vm => vm.LoadingCommand);
            BindingSet.Apply();
        }

        private void PrepareInfoButton()
        {
            var hero = FindViewById<Button>(Resource.Id.fifthview_info_button);
            hero.Text = DreamsResources.FifthView_Info_Button_Label;
            BindingSet.Bind(hero).To(vm => vm.InfoCommand);
            BindingSet.Apply();
        }
    }
}