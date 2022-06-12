namespace UChallenge.MockDB.FeiraLivreAggregates
{
    public sealed class FeiraLivreRepository :
        BaseRepository<Domain.FeiraLivreAggregates.FeiraLivre, FeiraLivre, long>,
        Domain.FeiraLivreAggregates.IFeiraLivreRepository
    {
        public FeiraLivreRepository(MockDbContext context) :
            base(context.FeirasLivres)
        {
        }
    }
}
