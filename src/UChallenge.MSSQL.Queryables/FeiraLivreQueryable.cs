using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates.Queryables;

namespace UChallenge.MSSQL.Queryables
{
    public sealed class FeiraLivreQueryable :
        IFeiraLivreQueryable
    {
        private const string CACHE_FEIRALIVRE_KEY = "FeirasLivre";
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public FeiraLivreQueryable(IMemoryCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<GetQueryResult> Get(GetQueryFilter queryFilter)
        {
            var items = await _cache.GetOrCreateAsync(CACHE_FEIRALIVRE_KEY, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                entry.SetPriority(CacheItemPriority.High);

                return await LoadFeirasLivresFromDataBase();
            });

            if (!string.IsNullOrEmpty(queryFilter.Nome))
                items = items.Where(item => item.Nome.Contains(queryFilter.Nome));
            if (!string.IsNullOrEmpty(queryFilter.Bairro))
                items = items.Where(item => item.Bairro.Contains(queryFilter.Bairro));
            if (!string.IsNullOrEmpty(queryFilter.NomeDistrito))
                items = items.Where(item => item.NomeDistrito.Contains(queryFilter.NomeDistrito));
            if (!string.IsNullOrEmpty(queryFilter.RegiaoEm5Areas))
                items = items.Where(item => item.RegiaoDivisaoEm5Areas.Contains(queryFilter.RegiaoEm5Areas));

            return new GetQueryResult(items.ToList());
        }

        private async Task<IQueryable<GetQueryResultItem>> LoadFeirasLivresFromDataBase()
        {
            var items = new List<GetQueryResultItem>();

            using SqlConnection sqlConnection = new(_configuration.GetConnectionString("UChallenge"));
            sqlConnection.Open();

            var sqlQuery = "SELECT" +
                "   Id, " +
                "   Nome," +
                "   Registro," +
                "   Longitude," +
                "   Latitude," +
                "   SetorCensitario, " +
                "   AreaPonderacao," +
                "   CodigoDistrito," +
                "   NomeDistrito," +
                "   CodigoSubprefeitura," +
                "   NomeSubprefeitura," +
                "   RegiaoDivisaoEm5Areas," +
                "   RegiaoDivisaoEm8Areas," +
                "   Logradouro," +
                "   Numero," +
                "   ISNULL(Bairro,'')," +
                "   ISNULL(Referencia,'') " +
                "FROM FEIRALIVRE " + 
                "ORDER BY Id";

            using SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sqlQuery;

            using SqlDataReader sqlDataReader = await sqlCommand.
                ExecuteReaderAsync(System.Data.CommandBehavior.SequentialAccess);
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var item = new GetQueryResultItem(
                        id: sqlDataReader.GetInt32(0),
                        nome: sqlDataReader.GetString(1),
                        registro: sqlDataReader.GetString(2),
                        longitude: sqlDataReader.GetDouble(3),
                        latitude: sqlDataReader.GetDouble(4),
                        setorCensitario: sqlDataReader.GetInt32(5),
                        areaPonderacao: sqlDataReader.GetInt64(6),
                        codigoDistrito: sqlDataReader.GetInt32(7),
                        nomeDistrito: sqlDataReader.GetString(8),
                        codigoSubPrefeitura: sqlDataReader.GetInt32(9),
                        nomeSubPrefeitura: sqlDataReader.GetString(10),
                        regiaoDivisaoEm5Areas: sqlDataReader.GetString(11),
                        regiaoDivisaoEm8Areas: sqlDataReader.GetString(12),
                        logradouro: sqlDataReader.GetString(13),
                        numero: sqlDataReader.GetString(14),
                        bairro: sqlDataReader.GetString(15),
                        referencia: sqlDataReader.GetString(16));

                    items.Add(item);
                }
            }

            return items.AsQueryable();
        }

        public void Invalidate()
        {
            _cache.Remove(CACHE_FEIRALIVRE_KEY);
        }
    }
}
