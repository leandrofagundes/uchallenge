using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.MSSQL.FeiraLivreAggregates
{
    internal class FeiraLivreConfiguration :
        IEntityTypeConfiguration<FeiraLivre>
    {
        public void Configure(EntityTypeBuilder<FeiraLivre> builder)
        {
            builder.ToTable("FeiraLivre");

            BuildIndexes(builder);

            BuildProperties(builder);
        }

        private static void BuildIndexes(EntityTypeBuilder<FeiraLivre> builder)
        {
            builder.HasKey(pk => pk.Id);
        }

        private static void BuildProperties(EntityTypeBuilder<FeiraLivre> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.NomeFeira)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.RegistroFeira)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(p => p.Longitude)
                .HasConversion(p => p.ToDouble(), u => new Longitude(u))
                .IsRequired();

            builder.Property(p => p.Latitude)
                .HasConversion(p => p.ToDouble(), u => new Latitude(u))
                .IsRequired();

            builder.Property(p => p.SetorCensitario)
                .IsRequired();

            builder.Property(p => p.AreaDePonderacao)
                .IsRequired();

            builder.Property(p => p.CodigoDistrito)
                .IsRequired();

            builder.Property(p => p.NomeDistrito)
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(p => p.CodigoSubPrefeitura)
                .IsRequired();

            builder.Property(p => p.NomeSubPrefeitura)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.RegiaoPorDivisaoEm5Areas)
                .IsRequired();

            builder.Property(p => p.RegiaoPorDivisaoEm8Areas)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(p => p.Logradouro)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(p => p.Bairro)
                .HasMaxLength(34);

            builder.Property(p => p.Referencia)
                .HasMaxLength(30);
        }
    }
}
