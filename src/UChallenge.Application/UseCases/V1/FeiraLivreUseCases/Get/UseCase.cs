using System;
using System.Threading.Tasks;

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
                var queryData = await GetData(inputData)
                    .ConfigureAwait(false);

                var outputData = BuildOutputData(queryData);

                _outputPort.Success(outputData);
            }
            catch (Exception ex)
            {
                _outputPort.UnhandledException(ex);
            }
        }

        private async Task<object> GetData(InputData inputData)
        {
            var queryResult = await _feiraLivreQueryable
                .Get(inputData)
                .ConfigureAwait(false);

            return queryResult;
        }

        private static OutputData BuildOutputData(object feiraLivre)
        {
            var outputDataItem = new OutputDataItem(
                feiraLivre.Id,
                feiraLivre.NomeFeira,
                feiraLivre.RegistroFeira,
                feiraLivre.Longitude,
                feiraLivre.Latitude,
                feiraLivre.SetorCensitario,
                feiraLivre.AreaDePonderacao,
                feiraLivre.CodigoDistrito,
                feiraLivre.NomeDistrito,
                feiraLivre.CodigoSubPrefeitura,
                feiraLivre.NomeSubPrefeitura,
                feiraLivre.RegiaoPorDivisaoEm5Areas,
                feiraLivre.RegiaoPorDivisaoEm8Areas,
                feiraLivre.Logradouro,
                feiraLivre.Numero,
                feiraLivre.Bairro,
                feiraLivre.Referencia);

            var outputData = new OutputData(null);
            return outputData;
        }
    }
}
