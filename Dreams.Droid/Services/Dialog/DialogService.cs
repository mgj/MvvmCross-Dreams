using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Dreams.Core.Services.Dialog;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace Dreams.Droid.Services.Dialog
{
    public class DialogService : IDialogService
    {
        private ProgressDialog _progressDialog;
        private AlertDialog _alertDialog;

        public void Info(string message)
        {
            if (CurrentContext == null)
            {
                return;
            }

            CurrentContext.RunOnUiThread(() =>
            {
                if (_alertDialog != null && _alertDialog.IsShowing)
                {
                    _alertDialog.SetMessage(message);
                }
                else
                {
                    _alertDialog = new AlertDialog.Builder(CurrentContext)
                        .SetPositiveButton("OK", (sender, e) => { })
                        .SetMessage(message)
                        .Show();
                }
            });
        }

        public void ShowLoading(string message, bool withProgress = false)
        {
            if (CurrentContext == null)
            {
                return;
            }

            CurrentContext.RunOnUiThread(() =>
            {
                if(_progressDialog == null || (_progressDialog != null && (_progressDialog.IsShowing == false)))
                {
                    _progressDialog = ProgressDialogFactory(CurrentContext, message, withProgress);
                }

                if(_progressDialog.IsShowing == false)
                {
                    _progressDialog.Show();
                }
            });
        }


        private static ProgressDialog ProgressDialogFactory(Context context, string message, bool withProgress)
        {
            var dialog = new ProgressDialog(context);
            if (withProgress)
            {
                dialog.SetProgressStyle(ProgressDialogStyle.Horizontal);
            }
            else
            {
                dialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            }

            dialog.SetMessage(message);

            return dialog;
        }


        public void LoadingProgress(int progress)
        {
            if (_progressDialog == null || CurrentContext == null)
            {
                return;
            }

            CurrentContext.RunOnUiThread(() =>
            {
                _progressDialog.Progress = progress;
                if (progress == 100)
                {
                    _progressDialog.Dismiss();
                }
            });

        }

        private Activity CurrentContext
        {
            get
            {
                if (Mvx.CanResolve<IMvxAndroidCurrentTopActivity>())
                {
                    return Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
                }

                return null;
            }
        }
    }
}