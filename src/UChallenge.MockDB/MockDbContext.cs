using System;
using System.Collections.Generic;
using UChallenge.MockDB.FeiraLivreAggregates;

namespace UChallenge.MockDB
{
    public sealed class MockDbContext :
        IDisposable
    {
        private bool disposedValue;

        public List<FeiraLivre> FeirasLivres { get; private set; }
        
        public MockDbContext()
        {
            FeirasLivres = new();
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    FeirasLivres.Clear();
                }

                FeirasLivres = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
