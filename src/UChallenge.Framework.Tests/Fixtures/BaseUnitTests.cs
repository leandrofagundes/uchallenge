using Xunit;

namespace UChallenge.Framework.Tests.Fixtures
{
    public abstract class BaseUnitTests<TFixture> :
        IClassFixture<TFixture>
        where TFixture : BaseFixture
    {
        protected readonly TFixture Fixtures;
        public BaseUnitTests(TFixture fixtures)
        {
            Fixtures = fixtures;
        }
    }
}
