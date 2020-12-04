using System.Net.Http;

namespace DataAccessLibrary
{
    public interface IAPIClient
    {
        HttpClient Client { get; }
    }
}