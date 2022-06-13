using System;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Domain.Properties;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.Repositories;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly IFeiraLivreRepository _feiraLivreRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPort _outputPort;

        public UseCase(
            IFeiraLivreRepository feiraLivreRepository,
            IUnitOfWork unitOfWork,
            IOutputPort outputPort)
        {
            _feiraLivreRepository = feiraLivreRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        public async Task RequestAsync(InputData inputData)
        {
            try
            {
                inputData.ThrowIfInvalidData();

                var feiraLivre = await GetValidFeiraLivre(inputData.Id)
                    .ConfigureAwait(false);

                ChangeFeiraLivreProperties(feiraLivre, inputData);

                _feiraLivreRepository
                    .Update(feiraLivre);

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
            catch (BusinessApplicationRecordNotFoundException notFoundEx)
            {
                _outputPort.NotFound(notFoundEx.Message);
            }
            catch (DomainException domainEx)
            {
                _outputPort.InvalidEntityData(domainEx.Message);
            }
            catch (Exception ex)
            {
                _outputPort.UnhandledException(ex);
            }
        }

        private async Task<FeiraLivre> GetValidFeiraLivre(int id)
        {
            var feiraLivre = await _feiraLivreRepository
                .FindAsync(id)
                .ConfigureAwait(false);

            if (feiraLivre is null)
                throw new BusinessApplicationRecordNotFoundException(Resources.FeiraLivre, id);

            return feiraLivre;
        }

        private static void ChangeFeiraLivreProperties(FeiraLivre feiraLivre, InputData inputData)
        {
            feiraLivre.UpdateProperties(
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
