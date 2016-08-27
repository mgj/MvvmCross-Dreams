
using Android.App;
using Android.Widget;
using Dreams.Droid.Views.Common;
using Dreams.Core.ViewModels.Second;
using Android.OS;
using System;
using Dreams.Core.Common;

namespace Dreams.Droid.Views.Second
{
    [Activity]
    public class SecondView : DreamsViewBase<SecondView, SecondViewModel>
    {
        protected override int ResourceLayoutId
        {
            get
            {
                return Resource.Layout.activity_secondview;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            PrepareTextView();
            PrepareButton();
        }

        private void PrepareButton()
        {
            var view = FindViewById<Button>(Resource.Id.secondview_show_third_button);
            view.Text = DreamsResources.SecondView_ShowThird_Button_Label;
            BindingSet.Bind(view).To(vm => vm.ShowThirdCommand);
            BindingSet.Apply();
        }

        private void PrepareTextView()
        {
            var view = FindViewById<TextView>(Resource.Id.secondview_textview);
            BindingSet.Bind(view).To(vm => vm.SecondData);
            BindingSet.Apply();
        }
    }
}