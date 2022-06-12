using System;
using System.Linq;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates.Queryables;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly IFeiraLivreQueryable _feiraLivreQueryable;
        private readonly IOutputPort _outputPort;

        public UseCase(
            IFeiraLivreQueryable feiraLivreQueryable,
            IOutputPort outputPort)
        {
            _feiraLivreQueryable = feiraLivreQueryable;
            _outputPort = outputPort;
        }

        public async Task RequestAsync(InputData inputData)
        {
            try
            {
                var queryResult = await GetData(inputData)
                    .ConfigureAwait(false);

                var outputData = BuildOutputData(queryResult);

                _outputPort.Success(outputData);
            }
            catch (Exception ex)
            {
                _outputPort.UnhandledException(ex);
            }
        }

        private async Task<GetQueryResult> GetData(InputData inputData)
        {
            var queryFilter = new GetQueryFilter
            {
                Bairro = inputData.Bairro,
                NomeDistrito = inputData.NomeDistrito,
                NomeFeira = inputData.NomeFeira,
                RegiaoEm5Areas = inputData.RegiaoPorDivisaoEm5Areas
            };

            var queryResult = await _feiraLivreQueryable
                .Get(queryFilter)
                .ConfigureAwait(false);

            return queryResult;
        }

        private static OutputData BuildOutputData(GetQueryResult queryResult)
        {
            var outputDataItem = queryResult
                .Items
                .Select(resultItem => new OutputDataItem(
                    resultItem.Id,
                    resultItem.NomeFeira,
                    resultItem.RegistroFeira,
                    new(resultItem.Longitude),
                    new(resultItem.Latitude),
                    resultItem.SetorCensitario,
                    resultItem.AreaDePonderacao,
                    resultItem.CodigoDistrito,
                    resultItem.NomeDistrito,
                    resultItem.CodigoSubPrefeitura,
                    resultItem.NomeSubPrefeitura,
                    resultItem.RegiaoPorDivisaoEm5Areas,
                    resultItem.RegiaoPorDivisaoEm8Areas,
                    resultItem.Logradouro,
                    resultItem.Numero,
                    resultItem.Bairro,
                    resultItem.Referencia));

            var outputData = new OutputData(outputDataItem);
            return outputData;
        }
    }
}
