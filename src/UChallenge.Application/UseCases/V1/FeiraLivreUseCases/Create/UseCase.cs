using System;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly IFeiraLivreFactory _feiraLivreFactory;
        private readonly IOutputPort _outputPort;

        public UseCase(
            IFeiraLivreFactory feiraLivreFactory,
            IOutputPort outputPort)
        {
            _feiraLivreFactory = feiraLivreFactory;
            _outputPort = outputPort;
        }

        public async Task RequestAsync(InputData inputData)
        {
            try
            {
                var feiraLivre = CreateFromInputData(inputData);

                var outputData = BuildOutputData(feiraLivre);

                _outputPort.Success(outputData);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _outputPort.UnhandledException(ex);
            }
        }

        private FeiraLivre CreateFromInputData(InputData inputData)
        {
            var feiraLivre = _feiraLivreFactory.Create(
                inputData.Id,
                inputData.NomeFeira,
                inputData.RegistroFeira,
                inputData.Longitude,
                inputData.Latitude,
                inputData.SetorCensitario,
                inputData.AreaDePonderacao,
                inputData.CodigoDistrito,
                inputData.NomeDistrito,
                inputData.CodigoSubPrefeitura,
                inputData.NomeSubPrefeitura,
                inputData.RegiaoPorDivisaoEm5Areas,
                inputData.RegiaoPorDivisaoEm8Areas,
                inputData.Logradouro,
                inputData.Numero,
                inputData.Bairro,
                inputData.Referencia);

            return feiraLivre;
        }

        private static OutputData BuildOutputData(FeiraLivre feiraLivre)
        {
            var outputData = new OutputData(
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

            return outputData;
        }
    }
}
