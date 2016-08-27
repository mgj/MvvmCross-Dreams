using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using System;
using System.Collections.Generic;

namespace Dreams.Core.Tests.Common
{
    public class MockDispatcher
    : MvxMainThreadDispatcher,
      IMvxViewDispatcher
    {
        private readonly List<MvxPresentationHint> _hints = new List<MvxPresentationHint>();
        private readonly List<MvxViewModelRequest> _requests = new List<MvxViewModelRequest>();

        public List<MvxViewModelRequest> Requests
        {
            get
            {
                return _requests;
            }
        }

        public List<MvxPresentationHint> Hints
        {
            get
            {
                return _hints;
            }
        }

        public bool RequestMainThreadAction(Action action)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            Requests.Add(request);
            return true;
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return true;
        }
    }
}