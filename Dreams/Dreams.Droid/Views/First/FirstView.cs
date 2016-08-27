using Android.OS;
using Dreams.Core.Common;
using Dreams.Core.ViewModels.First;
using Dreams.Droid.Views.Common;
using Android.App;
using Android.Widget;

namespace Dreams.Droid.Views.First
{
    [Activity]
    public class FirstView : DreamsViewBase<FirstView, FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            PrepareUI();
        }

        private void PrepareUI()
        {
            PrepareEditText();
            PrepareTextView();
            PrepareShowSecondButton();
        }

        private void PrepareShowSecondButton()
        {
            var hero = FindViewById<Button>(Resource.Id.firstview_show_second_button);
            hero.Text = DreamsResources.FirstView_ShowSecond_Button_Label;
            BindingSet.Bind(hero).To(vm => vm.ShowSecondCommand);
            BindingSet.Apply();
        }

        private void PrepareTextView()
        {
            var textview = FindViewById<TextView>(Resource.Id.firstview_textview);
            BindingSet.Bind(textview).To(vm => vm.Hello);
            BindingSet.Apply();
        }

        private void PrepareEditText()
        {
            var edittext = FindViewById<EditText>(Resource.Id.firstview_edittext);
            BindingSet.Bind(edittext).To(vm => vm.Hello).OneWayToSource();
            BindingSet.Apply();
        }

        protected override int ResourceLayoutId
        {
            get
            {
                return Resource.Layout.activity_firstview;
            }
        }
    }
}
