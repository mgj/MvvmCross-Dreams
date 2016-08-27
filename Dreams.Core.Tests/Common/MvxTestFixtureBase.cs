using Dreams.Core.Services.Calculator;
using Dreams.Core.Services.DreamsLog;
using Dreams.Core.Tests.Services.Calculator;
using Moq;
using MvvmCross.Core.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;

namespace Dreams.Core.Tests.Common
{
    public class MvxTestFixtureBase : MvxIoCSupportingTest
    {
        private MockDispatcher _mockDispatcher;

        public MvxTestFixtureBase()
        {
            Setup();
        }

        protected override void AdditionalSetup()
        {
            // Setup MVVMCross for testing
            _mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(_mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(_mockDispatcher);
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());

            // Register our own services
            Ioc.RegisterSingleton<ICalculatorService>(() => new CalculatorService());
        }
    }
}
