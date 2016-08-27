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
using Dreams.Core.ViewModels.Third;
using Dreams.Droid.Views.Common;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V4;

namespace Dreams.Droid.Views.Third
{
    [Activity]
    public class ThirdView : DreamsViewBase<ThirdView, ThirdViewModel>
    {
        protected override int ResourceLayoutId
        {
            get
            {
                return Resource.Layout.activity_thirdview;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            PrepareUI();
        }

        private void PrepareUI()
        {
            PrepareRecyclerView();
        }

        private void PrepareRecyclerView()
        {
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            recyclerView.ItemTemplateId = Resource.Layout.listitem_thirdview_recyclerview;
            BindingSet.Bind(recyclerView).For(x => x.ItemsSource).To(vm => vm.Data);
            BindingSet.Bind(recyclerView).For(x => x.ItemClick).To(vm => vm.ItemSelectedCommand);
            BindingSet.Apply();
        }
    }
}