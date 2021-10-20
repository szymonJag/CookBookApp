using System.Threading.Tasks;

namespace CookBookApp.Client.Services.HttpService
{
    public interface IHttpService
    {
        Task<T> Delete<T>(string uri);
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task<T> Put<T>(string uri, object value);
    }
}