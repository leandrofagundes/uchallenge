using System;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Domain.FeiraLivreAggregates.Queryables;
using UChallenge.Domain.Properties;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Repositories;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly IFeiraLivreRepository _feiraLivreRepository;
        private readonly IFeiraLivreQueryable _feiraLivreQueryable;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPort _outputPort;

        public UseCase(
            IFeiraLivreRepository feiraLivreRepository,
            IFeiraLivreQueryable feiraLivreQueryable,
            IUnitOfWork unitOfWork,
            IOutputPort outputPort)
        {
            _feiraLivreRepository = feiraLivreRepository;
            _feiraLivreQueryable = feiraLivreQueryable;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        public async Task RequestAsync(InputData inputData)
        {
            try
            {
                var feiraLivre = await GetValidFeiraLivre(inputData.Id)
                    .ConfigureAwait(false);

                _feiraLivreRepository
                    .Remove(feiraLivre);

                await _unitOfWork
                    .SaveChangesAsync()
                    .ConfigureAwait(false);

                await _feiraLivreQueryable
                    .InvalidateAsync()
                    .ConfigureAwait(false);

                _outputPort.Success();
            }
            catch (BusinessApplicationRecordNotFoundException notFoundEx)
            {
                _outputPort.NotFound(notFoundEx.Message);
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
    }
}
