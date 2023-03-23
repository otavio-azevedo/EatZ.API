using System.Text.Json;

namespace EatZ.Infra.CrossCutting.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string value = await content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(value);
        }
    }
}
