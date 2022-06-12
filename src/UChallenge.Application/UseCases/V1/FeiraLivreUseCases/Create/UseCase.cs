using System;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Domain.Properties;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.Repositories;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly IFeiraLivreFactory _feiraLivreFactory;
        private readonly IFeiraLivreRepository _feiraLivreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPort _outputPort;

        public UseCase(
            IFeiraLivreFactory feiraLivreFactory,
            IFeiraLivreRepository feiraLivreRepository,
            IUnitOfWork unitOfWork,
            IOutputPort outputPort)
        {
            _feiraLivreFactory = feiraLivreFactory;
            _feiraLivreRepository = feiraLivreRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        public async Task RequestAsync(InputData inputData)
        {
            try
            {
                inputData.ThrowIfInvalidData();

                var feiraLivre = CreateFromInputData(inputData);

                await ValidateUniqueData(feiraLivre)
                    .ConfigureAwait(false);

                await _feiraLivreRepository
                    .AddAsync(feiraLivre)
                    .ConfigureAwait(false);

                await _unitOfWork
                    .SaveChangesAsync()
                    .ConfigureAwait(false);

                var outputData = BuildOutputData(feiraLivre);

                _outputPort.Success(outputData);
            }
            catch (BusinessApplicationInvalidInputDataException invalidDataEx)
            {
                _outputPort.InvalidInputData(invalidDataEx.Errors);
            }
            catch (DomainException domainEx)
            {
                _outputPort.InvalidEntityData(domainEx.Message);
            }
            catch (BusinessApplicationDuplicateDataException duplicateDataEx)
            {
                _outputPort.DuplicatedData(duplicateDataEx.Message, duplicateDataEx.Value);
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
                inputData.Nome,
                inputData.Registro,
                inputData.Longitude,
                inputData.Latitude,
                inputData.SetorCensitario,
                inputData.AreaPonderacao,
                inputData.CodigoDistrito,
                inputData.NomeDistrito,
                inputData.CodigoSubPrefeitura,
                inputData.NomeSubPrefeitura,
                inputData.RegiaoDivisaoEm5Areas,
                inputData.RegiaoDivisaoEm8Areas,
                inputData.Logradouro,
                inputData.Numero,
                inputData.Bairro,
                inputData.Referencia);

            return feiraLivre;
        }

        private async Task ValidateUniqueData(FeiraLivre feiraLivre)
        {
            var exists = await _feiraLivreRepository
                .ExistsAsync(feiraLivre.Id)
                .ConfigureAwait(false);

            if (exists)
                throw new BusinessApplicationDuplicateDataException(Resources.FeiraLivre, feiraLivre.Id);
        }

        private static OutputData BuildOutputData(FeiraLivre feiraLivre)
        {
            var outputData = new OutputData(
                feiraLivre.Id,
                feiraLivre.Nome,
                feiraLivre.Registro,
                feiraLivre.Longitude,
                feiraLivre.Latitude,
                feiraLivre.SetorCensitario,
                feiraLivre.AreaPonderacao,
                feiraLivre.CodigoDistrito,
                feiraLivre.NomeDistrito,
                feiraLivre.CodigoSubPrefeitura,
                feiraLivre.NomeSubPrefeitura,
                feiraLivre.RegiaoDivisaoEm5Areas,
                feiraLivre.RegiaoDivisaoEm8Areas,
                feiraLivre.Logradouro,
                feiraLivre.Numero,
                feiraLivre.Bairro,
                feiraLivre.Referencia);

            return outputData;
        }
    }
}
