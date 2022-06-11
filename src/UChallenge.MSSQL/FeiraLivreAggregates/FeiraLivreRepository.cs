namespace UChallenge.MSSQL.FeiraLivreAggregates
{
    public sealed class FeiraLivreRepository :
        BaseRepository<Domain.FeiraLivreAggregates.FeiraLivre, FeiraLivre, long>,
        Domain.FeiraLivreAggregates.IFeiraLivreRepository
    {
        public FeiraLivreRepository(MSSqlServerDbContext context) :
            base(context)
        {
        }
    }
}
