using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.LocalStorageService
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime jsRuntime;

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetItem<T>(string key, T value)
        {
            var serializedObject = JsonSerializer.Serialize<T>(value);
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, serializedObject);
        }

        public async Task RemoveItem(string key)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
