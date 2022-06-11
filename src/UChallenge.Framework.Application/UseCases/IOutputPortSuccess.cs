namespace UChallenge.Framework.Application.UseCases
{
    public interface IOutputPortSuccess
    {
        void Success();
    }

    public interface IOutputPortSuccess<TOutputData> 
        where TOutputData : IOutputData
    {
        void Success(TOutputData outputData);
    }
}
