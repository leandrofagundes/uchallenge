using UChallenge.Framework.Application.Queryables;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public sealed class QueryFilter :
        IQueryFilter
    {
        public string NomeFeira { get; private set; }
        public int CodigoDistrito { get; private set; }
        public string NomeDistrito { get; private set; }
        public string RegiaoPorDivisaoEm5Areas { get; private set; }
        public string Bairro { get; private set; }

        public void AddFilterNomeFeira(string nomeFeira)
        {
            NomeFeira = nomeFeira;
        }

        public void AddFilterCodigoDistrito(int codigoDistrito)
        {
            CodigoDistrito = codigoDistrito;
        }

        public void AddFilterNomeDistritoFeira(string nomeDistrito)
        {
            NomeDistrito = nomeDistrito;
        }

        public void AddFilterRegiaoEm5Areas(string regiaoPorDivisaoEm5Areas)
        {
            RegiaoPorDivisaoEm5Areas = regiaoPorDivisaoEm5Areas;
        }

        public void AddFilterBairro(string bairro)
        {
            Bairro = bairro;
        }

    }
}
