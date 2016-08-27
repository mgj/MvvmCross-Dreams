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
using Dreams.Core.ViewModels.Fourth;
using Dreams.Droid.Views.Common;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace Dreams.Droid.Views.Fourth
{
    [Activity]
    public class FourthView : DreamsViewBase<FourthView, FourthViewModel>
    {
        protected override int ResourceLayoutId
        {
            get
            {
                return Resource.Layout.activity_fourthview;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
            PrepareUI();
        }

        private void PrepareUI()
        {
            PrepareBurgerMenu();
            PrepareContentA();
        }

        private void PrepareContentA()
        {
            var a = FindViewById<View>(Resource.Id.fourthview_content_a);
            var button = a.FindViewById<Button>(Resource.Id.content_fourthview_button);
            BindingSet.Bind(button).To(vm => vm.ShowFifthCommand);
            BindingSet.Apply();
        }

        private void PrepareBurgerMenu()
        {
            var drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            var a = FindViewById<View>(Resource.Id.fourthview_content_a);
            var b = FindViewById<View>(Resource.Id.fourthview_content_b);
            var c = FindViewById<View>(Resource.Id.fourthview_content_c);

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_a:
                        a.Visibility = ViewStates.Visible;
                        b.Visibility = ViewStates.Gone;
                        c.Visibility = ViewStates.Gone;
                        break;
                    case Resource.Id.nav_b:
                        a.Visibility = ViewStates.Gone;
                        b.Visibility = ViewStates.Visible;
                        c.Visibility = ViewStates.Gone;
                        break;
                    case Resource.Id.nav_c:
                        a.Visibility = ViewStates.Gone;
                        b.Visibility = ViewStates.Gone;
                        c.Visibility = ViewStates.Visible;
                        break;
                }

                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    var drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                    drawerLayout?.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}