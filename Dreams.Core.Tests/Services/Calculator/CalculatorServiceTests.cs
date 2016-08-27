using Dreams.Core.Services.Calculator;
using Dreams.Core.Tests.Common;
using MvvmCross.Platform;
using NUnit.Framework;

namespace Dreams.Core.Tests.Services.Calculator
{
    [TestFixture]
    public class CalculatorServiceTests : MvxTestFixtureBase
    {
        [Test]
        public void Add_Sunshine_CorrectValueReturned()
        {
            var sut = Mvx.Resolve<ICalculatorService>();

            var expected = 4;
            var result = sut.Add(2, 2);

            Assert.AreEqual(expected, result);
        }
    }
}
