using System;
using System.Threading.Tasks;

namespace Dreams.Core.Services.Dialog
{
    public interface IDialogService
    {
        void Info(string message);
        void ShowLoading(string message, bool withProgress = false);
        void LoadingProgress(int progress);
    }
}