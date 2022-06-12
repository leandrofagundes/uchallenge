using Xunit;

namespace UChallenge.Framework.Tests.Fixtures
{
    public abstract class BaseIntegrationTests<TFixture> :
        IClassFixture<TFixture>
        where TFixture : BaseFixture
    {
        protected readonly TFixture Fixtures;
        public BaseIntegrationTests(TFixture fixtures)
        {
            Fixtures = fixtures;
        }
    }
}
