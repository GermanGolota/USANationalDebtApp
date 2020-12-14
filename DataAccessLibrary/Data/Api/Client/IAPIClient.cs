using System.Net.Http;

namespace DataAccessLibrary.Data.API
{
    public interface IAPIClient
    {
        HttpClient Client { get; }
    }
}