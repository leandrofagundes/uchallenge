using System;

namespace UChallenge.Framework.Application.UseCases
{
    public interface IOutputPortUnhandledException
    {
        void UnhandledException(Exception ex);
    }
}
