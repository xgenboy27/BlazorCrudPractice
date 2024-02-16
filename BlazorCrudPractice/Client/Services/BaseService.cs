namespace BlazorCrudPractice.Client.Services
{
    public abstract class BaseService
    {
        public readonly HttpClient httpClient;

        public BaseService(HttpClient pHttpClient)
        {
            this.httpClient = pHttpClient;
        }
    }
}
