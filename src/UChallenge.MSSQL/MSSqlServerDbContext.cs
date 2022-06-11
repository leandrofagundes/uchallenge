using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UChallenge.MSSQL.FeiraLivreAggregates;

namespace UChallenge.MSSQL
{
    public sealed class MSSqlServerDbContext :
        DbContext
    {
        internal DbSet<FeiraLivre> FeirasLivres { get; private set; }

        public MSSqlServerDbContext(DbContextOptions options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RemovePluralizingTableNameConvention(modelBuilder);
        }

        private static void RemovePluralizingTableNameConvention(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
